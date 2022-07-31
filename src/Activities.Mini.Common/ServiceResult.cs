using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activities.Mini.Common
{
    public class ServiceResult<TResult> : ServiceResult where TResult : class
    {
        public TResult Result
        {
            get;
            set;
        }
    }
    public class ServiceResult
    {
        public int StatusCode
        {
            get;
            set;
        }

        public string? Message
        {
            get;
            set;
        } = "请求成功";


        public static ServiceResult<TResult> Succeed<TResult>(TResult result = null, string message = "请求成功") where TResult : class
        {
            return new ServiceResult<TResult>
            {
                Result = result,
                Message = message
            };
        }

        public static ServiceResult Succeed(string message = "请求成功")
        {
            return new ServiceResult
            {
                Message = message
            };
        }

        public static ServiceResult Failed(int statusCode, string message)
        {
            return new ServiceResult
            {
                StatusCode = statusCode,
                Message = message
            };
        }

        public static ServiceResult<TResult> Failed<TResult>(TResult errorResult, int statusCode, string message) where TResult : class
        {
            return new ServiceResult<TResult>
            {
                StatusCode = statusCode,
                Message = message,
                Result = errorResult
            };
        }

        public static ServiceResult From(int statusCode, string message = null)
        {
            return new ServiceResult
            {
                StatusCode = statusCode,
                Message = message
            };
        }

        public static ServiceResult<TResult> From<TResult>(TResult result, int statusCode, string message) where TResult : class
        {
            return new ServiceResult<TResult>
            {
                StatusCode = statusCode,
                Message = message,
                Result = result
            };
        }
    }
}
