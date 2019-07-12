using api_inventory.Models;
using api_inventory.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace api_inventory.Controllers
{
    [Produces("application/json")]      
    public class InventoryController : Controller  
    {  
        IRepository Repository;  
        public InventoryController(IRepository _Repository)  
        {  
            Repository = _Repository;  
        }

        [Route("api/Version")]
        [HttpGet]
        public ActionResult<string> Version()
        {
            return Repository.Version();
        }

        [Route("api/Store")]
        [HttpGet]
        public ActionResult<string> Store()
        {
            return Repository.Store();
        }

        [Route("api/Inventory")]
        [HttpGet]
        public async Task<ActionResult<List<Inventory>>> Inventory()  
        {
            return await Repository.Inventory();    
        }  
  
        [Route("api/Inventory/{Id}")]  
        [HttpGet]
        public async Task<ActionResult<Inventory>> Inventory(int Id)  
        {  
            return await Repository.Inventory(Id);  
        } 

        [Route("api/Remove")]  
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Remove(int Id)  
        {  
            return await Repository.Remove(Id);  
        }  
    }  
}