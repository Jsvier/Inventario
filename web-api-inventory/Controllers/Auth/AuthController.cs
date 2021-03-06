using System.Security.Claims;
using System.Threading.Tasks;
using api_inventory.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using web_api_inventory.Helpers;
using web_api_inventory.jwt;
using web_api_inventory.Model.View;

namespace web_api_inventory.Controllers {
    
    [Route ("api/[controller]")]
    public class AuthController : Controller {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtOptions _jwtOptions;

        public AuthController (UserManager<AppUser> userManager, IJwtFactory jwtFactory, IOptions<JwtOptions> jwtOptions) {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost ("login")]
        public async Task<IActionResult> Post ([FromBody] CredentialsViewModel credentials) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }

            var identity = await GetClaimsIdentity (credentials.UserName, credentials.Password);
            if (identity == null) {
                return BadRequest (ErrorHelper.AddErrorToModelState ("login_failure", "Invalid username or password.", ModelState));
            }

            var jwt = await TokenGenerator.GenerateJwt (
                identity,
                _jwtFactory,
                credentials.UserName,
                _jwtOptions,
                new JsonSerializerSettings { Formatting = Formatting.Indented });

            return new OkObjectResult (jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity (string userName, string password) {
            if (string.IsNullOrEmpty (userName) || string.IsNullOrEmpty (password))
                return await Task.FromResult<ClaimsIdentity> (null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync (userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity> (null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync (userToVerify, password)) {
                return await Task.FromResult (_jwtFactory.GenerateClaimsIdentity (userName, userToVerify.Id));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity> (null);
        }
    }
}