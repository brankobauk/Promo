using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class Product
    {
        public Product()
        {
            PromotionProduct = new List<PromotionProduct>();
        }
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public decimal PriceDiscount { get; set; }
        public string Url { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        private ICollection<PromotionProduct> PromotionProduct { get; set; }
        private Country Country { get; set; }
        private Brand Brand { get; set; }
    }
}
