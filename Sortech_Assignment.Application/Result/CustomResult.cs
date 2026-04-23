using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.Result
{
    public class CustomResult<T>

    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public CustomError? Error { get; set; }  
        
        private T? _result { get; set; }
        public T? Result
        {
            get
            {
                if (IsFailure)
                    throw new InvalidOperationException("Cannot access result of a failed operation.");
                return _result;
            }
            private init { _result = value; }
        }
        private CustomResult(T value)
        {
            IsSuccess = true;
            _result = value;
        }
        private CustomResult(CustomError error)
        {
            IsSuccess = false;
            Error = error;
        }
        public static CustomResult<T> Success(T value) => new CustomResult<T>(value);
        public static CustomResult<T> Failure(CustomError error) => new CustomResult<T>(error);

    }
    public class CustomResult

    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public CustomError? Error { get; set; }

        
        private CustomResult()
        {
            IsSuccess = true;
            
        }
        private CustomResult(CustomError error)
        {
            IsSuccess = false;
            Error = error;
        }
        public static CustomResult Success() => new CustomResult();
        public static CustomResult Failure(CustomError error) => new CustomResult(error);

    }
}
