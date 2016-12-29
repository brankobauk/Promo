using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class Store
    {
        public Store()
        {
            PromotionStore = new List<PromotionStore>();
        }
        [Key]
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int CompanyId { get; set; }
        private Company Company { get; set; }
        private ICollection<PromotionStore> PromotionStore { get; set; }
    }
}
