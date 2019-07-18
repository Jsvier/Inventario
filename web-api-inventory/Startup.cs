using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Steeltoe.CircuitBreaker.Hystrix;
using Swashbuckle.AspNetCore.Swagger; //for metrics
using System;
using System.Text;
using api_inventory.Helpers;
using api_inventory.Interface;
using api_inventory.Model;
using api_inventory.Repositories;
using api_inventory.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using web_api_inventory.Helpers;
using web_api_inventory.jwt;
using web_api_inventory.jwt.repository;
using web_api_inventory.repository;

namespace api_inventory {
    public class Startup {
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey (Encoding.ASCII.GetBytes (SecretKey));

        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddCors ();

            services.AddTransient<IRepository, Repository> ();
            services.AddSingleton<IConfiguration> (Configuration);
            services.AddTransient<IJwtFactory, JwtFactory> ();

            // Patron repository
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper> ();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1", new Info {
                    Version = "v1",
                        Title = "API Inventario",
                        Description = "Core Web API Inventario",
                        TermsOfService = "None",
                        Contact = new Contact {
                            Name = "Javier Etchepare",
                                Email = string.Empty,
                                Url = string.Empty
                        },
                        License = new License {
                            Name = "Makro S.A.",
                                Url = "https://makro.com/license"
                        }
                });
            });

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection ("AppSettings");
            services.Configure<AppSettings> (appSettingsSection);

            // api user claim policy
            services.AddAuthorization (options => {
                options.AddPolicy ("ApiUser", policy => policy.RequireClaim (ConstantJwt.Strings.JwtClaimIdentifiers.Rol, ConstantJwt.Strings.JwtClaims.ApiAccess));
            });

            // Autentificacion EF con JWT
            services.AddDbContext<ApplicationDbJWTContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("efjwt")));

            // add identity
            var builder = services.AddIdentityCore<AppUser> (o => {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder (builder.UserType, typeof (IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbJWTContext> ().AddDefaultTokenProviders ();

            var jwtOptions = Configuration.GetSection (nameof (JwtOptions));
            services.Configure<JwtOptions> (options => {
                options.Issuer = jwtOptions[nameof (JwtOptions.Issuer)];
                options.Audience = jwtOptions[nameof (JwtOptions.Audience)];
                options.SigningCredentials = new SigningCredentials (_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidIssuer = jwtOptions[nameof (JwtOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtOptions[nameof (JwtOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            // A este punto ya tenemos protegido nuestra API para que implemente autenticación o acceso basado en token. Luego le decimos a ASP.NET Core que lo use en el runtime.
            services.AddAuthentication (options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer (configureOptions => {
                    configureOptions.ClaimsIssuer = jwtOptions[nameof (JwtOptions.Issuer)];
                    configureOptions.TokenValidationParameters = tokenValidationParameters;
                    configureOptions.SaveToken = true;
                });

            // Uso de autenticación
            services.AddAuthorization (options => {
                options.AddPolicy ("ApiUser", policy => policy.RequireClaim (ConstantJwt.Strings.JwtClaimIdentifiers.Rol, ConstantJwt.Strings.JwtClaims.ApiAccess));
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService> ();

            //add QueryCommand to service container, and inject into controller so it gets config values
            services.AddHystrixCommand<InventoryService> ("Inventory", Configuration);

            //added to get Metrics stream
            services.AddHystrixMetricsStream (Configuration);

            // add redis cache service
            services.AddDistributedRedisCache (options => {
                options.Configuration = Configuration.GetConnectionString ("Redis");
                options.InstanceName = "User_";
            });

            services.AddSession ();
            services.AddAutoMapper ();
            services.AddMvc ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger ();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI (c => {
                    c.SwaggerEndpoint ("/swagger/v1/swagger.json", "API V1");
                });
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            // global cors policy
            app.UseCors (x => x
                .AllowAnyOrigin ()
                .AllowAnyMethod ()
                .AllowAnyHeader ());
            app.UseAuthentication ();
            app.UseHttpsRedirection ();
            app.UseMvc ();

            //added
            app.UseHystrixRequestContext ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //added
            app.UseHystrixMetricsStream ();
            app.UseAuthentication ();
        }
    }
}