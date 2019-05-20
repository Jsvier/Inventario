using System;
using System.ComponentModel.DataAnnotations;

namespace api_inventory.Models
{
     public class Recommendations {

        private string productId;
        private string productImage;
        private string productDescription;

        public string ProductId {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductImage {
            get { return productImage; }
            set { productImage = value; }
        }

        public string ProductDescription {
            get { return productDescription; }
            set { productDescription = value; }
        }
    }
}