using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api_inventory.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using web_api_inventory.Helpers;
using web_api_inventory.jwt;
using web_api_inventory.jwt.repository;
using web_api_inventory.Model.View;

namespace web_api_inventory.Controllers {
    //[Authorize (Policy = "ApiUser")]
    [Route ("api/[controller]")]
    public class ProfileController : Controller {
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationDbJWTContext _appDbContext;

        public ProfileController (UserManager<AppUser> userManager, ApplicationDbJWTContext appDbContext, IHttpContextAccessor httpContextAccessor) {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            //  var userId = _caller.Claims.Single (c => c.Type == "id"); 
            // var customer = await _appDbContext.Customers.Include (c => c.Identity).SingleAsync (c => c.Identity.Id == userId.Value);
            var customer = new Customer();

            return new OkObjectResult (new {
                Message = "This is secure API and user data!",
                    customer.Identity.Name,
                    customer.Identity.NickName,
                    customer.Identity.PictureUrl,
                    customer.Identity.FacebookId,
                    customer.Location,
                    customer.Locale,
                    customer.Gender
            });
        }
    }
}