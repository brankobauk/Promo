using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class PromotionBrand
    {
        [Key]
        public int PromotionBrandId { get; set; }
        public int PromotionId { get; set; }
        public int BrandId { get; set; }
        private Brand Brand { get; set; }
        private Promotion Promotion { get; set; }
    }
}
