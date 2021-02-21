using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EditProduct
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Product Name Required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Price Required")]
        public decimal Price { get; set; }
        public int Discount { get; set; }
        [Required(ErrorMessage = "Product Quantity Required")]
        public int Quantity { get; set; }
    }
}
