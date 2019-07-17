using System.Threading.Tasks;
using api_inventory.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_inventory.Helpers;
using web_api_inventory.jwt.repository;
using web_api_inventory.Models;

namespace api_inventory.Controllers {

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

                    var result = await _userManager.CreateAsync (userIdentity, model.Password);

            //        if (!result.Succeeded) return new BadRequestObjectResult (ErrorHelper.AddErrorsToModelState (result, ModelState));

            //      await _appDbContext.Customers.AddAsync (new Customer { IdentityId = userIdentity.Id, Location = model.Location });
            //    await _appDbContext.SaveChangesAsync ();

            return new OkObjectResult ("Account succesfully created!");
        }
    }
}