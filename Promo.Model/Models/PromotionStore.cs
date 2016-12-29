using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class PromotionStore
    {
        [Key]
        public int PromotionStoreId { get; set; }
        public int PromotionId { get; set; }
        public int StoreId { get; set; }
        private Promotion Promotion { get; set; }
        private Store Store { get; set; }
    }
}
