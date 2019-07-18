using Microsoft.AspNetCore.Mvc;
using api_inventory.Services;
using api_inventory.Model;
using System.Collections.Generic;

namespace api_inventory.Controllers
{
    [Produces("application/json")]    
  public class HomeController : Controller
    {
        public HomeController(InventoryService rs) {
            this.rs = rs;
        }

        InventoryService rs;

        public IActionResult Index()
        {
            //call Hystrix-protected service
            List<Parameter> nls_config = rs.Execute();

            return Ok(nls_config);  
        }

        public IActionResult Error()
        {
            return Ok("result");  
        }
    }
}