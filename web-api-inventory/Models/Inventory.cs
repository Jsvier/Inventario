using System;

namespace api_inventory.Models
{
    public class Inventory {
         
        public int INV_NO { get; set; }
        public DateTime DATE_PLANNED { get; set; }
        public int STORE_NO { get; set; }
        public string TIPO { get; set; }
        public string STATUS { get; set; }
        public string DESCRIPCION { get; set; }
        public string NLS_DATE_LANGUAGE { get; set; }
        public string NLS_CHARACTERSET { get; set; }
        public string NLS_SORT { get; set; }
        public string NLS_TIME_FORMAT { get; set; }
        public string NLS_TIMESTAMP_FORMAT { get; set; }
        public string NLS_TIME_TZ_FORMAT { get; set; }
        public string NLS_TIMESTAMP_TZ_FORMAT { get; set; }
        public string NLS_DUAL_CURRENCY { get; set; }
        public string NLS_NCHAR_CHARACTERSET { get; set; }
        public string NLS_COMP { get; set; }
        public string NLS_LENGTH_SEMANTICS { get; set; }
        public string NLS_NCHAR_CONV_EXCP { get; set; }

    }
}