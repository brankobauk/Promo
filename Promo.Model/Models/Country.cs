using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class Country
    {
        public Country()
        {
            Promotion = new List<Promotion>();
            Product = new List<Product>();
        }
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
        private ICollection<Promotion> Promotion { get; set; }
        private ICollection<Product> Product { get; set; }
    }
}
