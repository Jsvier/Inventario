using System;
using System.ComponentModel.DataAnnotations;

namespace api_inventory.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Token { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }
       
        public string Initial { get; set; }
       
        public string Error { get; set; }
    }
}