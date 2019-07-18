using System.Threading.Tasks;
using api_inventory.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using web_api_inventory.Helpers;
using web_api_inventory.jwt.repository;
using web_api_inventory.Model.View;

namespace api_inventory.Controllers
{

    [ApiController]
    [Route ("[controller]")]
    public class AccountsController : Controller {
        private readonly ApplicationDbJWTContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsController (UserManager<AppUser> userManager, ApplicationDbJWTContext appDbContext, IMapper mapper) {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] RegistrationViewModel model) {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            var userIdentity = _mapper.Map<AppUser> (model);

            userIdentity.UserName= "bablbla"; //TODO: CAMBIAR
            
            var result = await _userManager.CreateAsync (userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult (ErrorHelper.AddErrorsToModelState (result, ModelState));

            await _appDbContext.Customers.AddAsync (new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync ();

            return new OkObjectResult ("Cuenta Creada");
        }
    }
}