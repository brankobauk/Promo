using Promo.DataLayer.Repositories;
using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Errors
{
    public class ErrorHandler
    {
        private readonly ErrorRepository _errorRepository = new ErrorRepository();
        public void Log(Error error)
        {
            _errorRepository.Log(error);
        }
    }
}
