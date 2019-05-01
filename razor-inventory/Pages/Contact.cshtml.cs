using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_inventory.Pages
{
    public class ContactModel : PageModel
    {
     
        ///carga de temporal
        [TempData]
        public string name { get; set; }
        public string Message { get; private set; } = "mensajeC#";

        public void OnGet(int id)
        {
            Message += $" Server time is { DateTime.Now }";
        }
     
    }
}
