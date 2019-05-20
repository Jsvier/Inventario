using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api_inventory.Services;
using api_inventory.Models;
using api_inventory.Entities;
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
            NLS_Config nls_config = rs.Execute();

            return Ok(nls_config);  
        }

        public IActionResult Error()
        {
            return Ok("result");  
        }
    }
}
