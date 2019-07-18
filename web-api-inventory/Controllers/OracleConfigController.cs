using api_inventory.Model;
using api_inventory.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace api_inventory.Controllers
{
    [Produces("application/json")]
   [Route("api/[controller]")]
    public class OracleConfigController : Controller
    {
        IRepository Repository;  
        public OracleConfigController(IRepository _Repository)  
        {  
            Repository = _Repository;  
        }  
  
        [HttpGet]
        public async  Task<ActionResult<List<Parameter>>> Get()
        {
            return await Repository.OracleConfig();
        }

    }
}