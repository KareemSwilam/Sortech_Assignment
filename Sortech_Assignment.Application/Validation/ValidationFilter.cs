using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sortech_Assignment.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sortech_Assignment.Application.Validation
{
    public class ValidationFilter<T>: IAsyncActionFilter where T : class
    {
        private readonly IValidator<T> _validator;

        public ValidationFilter(IValidator<T> validator)
        {
            _validator = validator;
        }
   
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var argument = context.ActionArguments.Values.OfType<T>().FirstOrDefault(); 
            if(argument is null)
            {
                await next();
                return;
            }
            var result = await _validator.ValidateAsync(argument);
            if (!result.IsValid)
            {
                var Error = CustomResult.Failure(CustomError.ValidationError(result.Errors.Select(e => e.ErrorMessage).ToList()));
                context.Result = new  BadRequestObjectResult(Error);
                return;
            }
            await next();
        }
    }
}
