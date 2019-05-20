using System;
using System.ComponentModel.DataAnnotations;

namespace api_inventory.Models
{
     public class NLS_Config {
         
        public string NLS_LANGUAGE { get; set; }
        public string NLS_TERRITORY { get; set; }
        public string NLS_CURRENCY { get; set; }
        public string NLS_ISO_CURRENCY { get; set; }
        public string NLS_NUMERIC_CHARACTERS { get; set; }
        public string NLS_DATE_FORMAT { get; set; }
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