using Promo.Model.Models;
using System;
namespace Promo.Helpers.Mappers
{
    public class ErrorMapper
    {
        public Error MapError(Exception ex, string url)
        {
            var error = new Error();
            error.Message = ex.Message;
            error.StackTrace = ex.StackTrace;
            error.Type = ex.GetType().Name;
            error.Url = url;
            error.Timestamp = DateTime.Now;
            return error;
        }
    }
}
