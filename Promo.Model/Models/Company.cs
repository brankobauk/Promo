using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class Company
    {
        public Company()
        {
            Promotion = new List<Promotion>();
        }
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        private ICollection<Promotion> Promotion { get; set; }
    }
}
