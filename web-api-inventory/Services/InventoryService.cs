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
    public class InventoryService: HystrixCommand<NLS_Config>
    {      
        public InventoryService(IHystrixCommandOptions options):base(options) {
        
        }

        protected override NLS_Config Run()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://localhost:5000/api/NLS_Config").Result;

            var nls_config = response.Content.ReadAsAsync<NLS_Config>().Result;

            return nls_config;
        }

        //fails
        protected override NLS_Config RunFallback()
        {
            NLS_Config nls_config = new NLS_Config();
            
            return nls_config;
        }
    }
}