using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.DataLayer.Repositories
{
    public class ErrorRepository
    {
        public void Log(Error error)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Error.Add(error);
                _db.SaveChanges();
            }

        }
    }
}
