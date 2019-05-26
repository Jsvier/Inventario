using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.CircuitBreaker.Hystrix;
using System.Net.Http; //for Http calls
using api_inventory.Models;

namespace api_inventory.Services
{
    //HystrixCommand means no result, HystrixCommand<string> means a string comes back
    public class InventoryService: HystrixCommand<List<Parameter>>
    {      
        public InventoryService(IHystrixCommandOptions options):base(options) {
        
        }

        protected override List<Parameter> Run()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:5000/api/OracleConfig").Result;

            var nls_config = response.Content.ReadAsAsync<List<Parameter>>().Result;

            return nls_config;
        }

        //fails
        protected override List<Parameter> RunFallback()
        {
            return new List<Parameter>();
            
        }
    }
}