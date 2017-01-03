using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Promo.Model.ViewModels
{
    public class StoreViewModel
    {
        public Store Store { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
    }
}
