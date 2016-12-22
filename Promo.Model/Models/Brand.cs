using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class Brand
    {
        public Brand()
        {
            Product = new List<Product>();
            PromotionBrand = new List<PromotionBrand>();
        }
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string Name { get; set; }

        private ICollection<Product> Product { get; set; }
        private ICollection<PromotionBrand> PromotionBrand { get; set; }
    }
}
