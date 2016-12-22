using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class PromotionProduct
    {
        [Key]
        public int PromotionProductId { get; set; }
        public int PromotionId { get; set; }
        public int ProductId { get; set; }
        private Promotion Promotion { get; set; }
        private Product Product { get; set; }
    }
}
