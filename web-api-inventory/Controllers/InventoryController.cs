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
        public  async Task<ActionResult<string>> Version()  
        {  
            return await Repository.Version();                 
        }  
  
        [Route("api/Store")]
        [HttpGet]
        public async Task<ActionResult<string>> Store()  
        {  
            return await Repository.Store();  
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
    }  
}  