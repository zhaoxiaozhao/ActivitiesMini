namespace Activities.Mini.Common
{
    public interface IApiResult
    {
        int StatusCode
        {
            get;
            set;
        }

        string Message
        {
            get;
            set;
        }
    }

    public interface IApiResult<T> : IApiResult
    {
        T Data
        {
            get;
            set;
        }
    }

    public class ApiResult<TResult> : ApiResult, IApiResult<TResult>, IApiResult
    {
        public TResult Data
        {
            get;
            set;
        }

        public ApiResult()
        {
        }

        public ApiResult(TResult data, int? statusCode, string message = "")
        {
            base.StatusCode = statusCode.GetValueOrDefault();
            base.Message = (string.IsNullOrEmpty(message) ? "请求成功" : message);
            Data = data;
        }
    }

    public class ApiResult : IApiResult
    {
        public static readonly IApiResult Empty = new ApiResult
        {
            StatusCode = 0,
            Message = "请求成功"
        };

        public int StatusCode
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public static IApiResult<TResult> Succeed<TResult>(TResult result, string message = "请求成功")
        {
            return new ApiResult<TResult>
            {
                Data = result,
                Message = message
            };
        }

        public static IApiResult Succeed(string message)
        {
            return new ApiResult
            {
                Message = message
            };
        }

        public static IApiResult Failed(string message, int? statusCode = null)
        {
            return new ApiResult
            {
                StatusCode = statusCode.GetValueOrDefault(),
                Message = message ?? string.Empty
            };
        }

        public static IApiResult<TResult> Failed<TResult>(TResult errorResult, string message, int? statusCode = null)
        {
            return new ApiResult<TResult>
            {
                StatusCode = statusCode.GetValueOrDefault(),
                Message = message ?? string.Empty,
                Data = errorResult
            };
        }

        public static IApiResult From(int statusCode, string? message = null)
        {
            return new ApiResult
            {
                StatusCode = statusCode,
                Message = message ?? string.Empty
            };
        }

        public static IApiResult<TResult> From<TResult>(TResult result, int statusCode, string message)
        {
            return new ApiResult<TResult>
            {
                StatusCode = statusCode,
                Message = message,
                Data = result
            };
        }

        public static IApiResult From(ServiceResult serviceResult)
        {
            return new ApiResult
            {
                Message = serviceResult.Message ?? string.Empty,
                StatusCode = serviceResult.StatusCode
            };
        }

        public static IApiResult<TResult> From<TResult>(ServiceResult<TResult> serviceResult) where TResult : class
        {
            return new ApiResult<TResult>
            {
                StatusCode = serviceResult.StatusCode,
                Message = serviceResult.Message ?? string.Empty,
                Data = serviceResult.Result
            };
        }
    }
}