using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class Promotion
    {
        public Promotion()
        {
            PromotionProduct = new List<PromotionProduct>();
            PromotionBrand = new List<PromotionBrand>();
            PromotionStore = new List<PromotionStore>();
        }
        [Key]
        public int PromotionId { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime EndDate { get; set; }

        private ICollection<PromotionProduct> PromotionProduct { get; set; }
        private ICollection<PromotionBrand> PromotionBrand { get; set; }
        private ICollection<PromotionStore> PromotionStore { get; set; }
        private Company Company { get; set; }
        private Country Country { get; set; }
    }
}
