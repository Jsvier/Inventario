using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api_inventory.Services;
using api_inventory.Models;
using api_inventory.Entities;
using api_inventory.Repositories;
using System.Collections.Generic;
using api_inventory.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace api_inventory.Controllers
{
  [Produces("application/json")]
   [Route("api/[controller]")]
    public class NLS_ConfigController : Controller
    {
        IRepository Repository;  
        public NLS_ConfigController(IRepository _Repository)  
        {  
            Repository = _Repository;  
        }  
  
        // GET api/recommendations
        [HttpGet]
        public NLS_Config Get()
        {
            
            var result = Repository.NLS_Config();  
            if (result == null)  
            {  
                return (null);  
            }  

            return result;       

        }
    }
}