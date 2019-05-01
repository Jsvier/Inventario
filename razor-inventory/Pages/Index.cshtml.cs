using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;

namespace razor_inventory.Pages
{
    public class IndexModel : PageModel
    {
     
        [BindProperty]
        public Customer customer { get; set; }
        [BindProperty]
        public Ciudad ciudad { get; set; }

        [TempData]
        public string name { get; set; }
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Ciudad
        {
            [Range (0,2000)]
            public int? Id { get; set; }


        [Required(ErrorMessage="El campo {0} es requerid")]
        [StringLength(20)]
        public string Name { get; set; }
        }

        public enum Item
        {
            [Display (Name = "Escoger item" )]
            None=0,
        }
        public string Message { get; private set; } = "PageModel in C#";

        public ILogger Logger { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            Logger = logger;
            logger.LogWarning("LogWarning");
        }
        //por injeccion de dependencias, solo un metodo instancia la implementacion y no lq totalidad
        public void OnGet([FromServices] IEmailServices EmailService)
        {
            Message = EmailService.SendMail() ;

        }
        public IActionResult OnPostCustomer()
        {
            return RedirectToPage("Contact");
        }

    }
}
