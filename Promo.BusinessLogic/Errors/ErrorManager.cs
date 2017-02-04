using Promo.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.BusinessLogic.Errors
{
    public class ErrorManager
    {
        private readonly ErrorHandler _errorHandler = new ErrorHandler();
        public void Log(Error error)
        {
            _errorHandler.Log(error);
        }
    }
}
