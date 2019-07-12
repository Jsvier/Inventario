using web_api_inventory.repository;
using Microsoft.AspNetCore.Mvc;
using api_inventory.Services;
using api_inventory.Models;
using System.Collections.Generic;

namespace web_api_inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
    
        public ValuesController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var nameUser = _repoWrapper.User.FindByCondition(x => x.Name.Equals("Javier"));
        
            return new string[] { "value1", "value2" };
        }
    }
}