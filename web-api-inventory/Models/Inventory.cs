using System;

namespace api_inventory.Models
{
    public class Inventory {
         
        public int id { get; set; }
        public DateTime DATE_PLANNED { get; set; }
        public int STORE_NO { get; set; }
        public string TIPO { get; set; }
        public string STATUS { get; set; }
        public string DESCRIPCION { get; set; }
    }
}