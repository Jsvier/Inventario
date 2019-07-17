using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Steeltoe.CircuitBreaker.Hystrix;
using Swashbuckle.AspNetCore.Swagger; //for metrics
using System.Text;
using api_inventory.Helpers;
using api_inventory.Interface;
using api_inventory.Models;
using api_inventory.Repositories;
using api_inventory.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_inventory.jwt.repository;
using web_api_inventory.Models;
using web_api_inventory.repository;

namespace api_inventory {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddCors ();

            services.AddTransient<IRepository, Repository> ();
            services.AddSingleton<IConfiguration> (Configuration);

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

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings> ();
            var key = Encoding.ASCII.GetBytes (appSettings.Secret);
            services.AddAuthentication (x => {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer (x => {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey (key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
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
        }
    }
}