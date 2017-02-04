using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Model.Models
{
    public class Error
    {
        [Key]
        public int ErrorId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string StackTrace { get; set; }
        public DateTime Timestamp { get; set; }
        public int? UserId { get; set; }
        public int? SiteId { get; set; }
        public string Url { get; set; }
    }
}
