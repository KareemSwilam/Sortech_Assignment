using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.Result
{
    public class CustomError
    {
        public string Code { get; set; }
        public List<string> Messages { get; set; } 
        private static readonly string _NotFoundCode = "Record Not Found";
        private static readonly string _ValidationErrorCode = "Validation Error";
        private static readonly string _ServerErrorCode = "Server Error";
        private CustomError(string code, List<string> messages)
        {
            Code = code;
            Messages = messages;
        }
        public static CustomError NotFound(List<string> messages) => new CustomError(_NotFoundCode,   messages); 
        public static CustomError ValidationError(List<string> messages) => new CustomError(_ValidationErrorCode, messages);
        public static CustomError ServerError(List<string> messages) => new CustomError(_ServerErrorCode, messages);

    }
}
