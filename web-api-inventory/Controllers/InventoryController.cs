using api_inventory.Repositories;  
using Microsoft.AspNetCore.Mvc; 
using api_inventory.Model;
  
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
        public ActionResult Version()  
        {  
            var result = Repository.Version();  
            if (result == null)  
            {  
                return NotFound();  
            }  

            return Ok(result);                   
        }  
  
        [Route("api/Store")]
        [HttpGet]
        public ActionResult Store()  
        {  
            var result = Repository.Store();  
            if (result == null)  
            {  
                return NotFound();  
            }  

            return Ok(result);                   
        }  

        [Route("api/Inventory")]
        [HttpGet]
        public ActionResult Inventory()  
        {  
            var result = Repository.Inventory();  
            if (result == null)  
            {  
                return NotFound();  
            }  

            return Ok(result);           
        }  
  
        [Route("api/Inventory/{Id}")]  
        [HttpGet]
        public ActionResult Inventory(int Id)  
        {  
            var result = Repository.Inventory(Id);  
            if (result == null)  
            {  
                return NotFound();  
            }

            return Ok(result);  
        }  
    }  
}  