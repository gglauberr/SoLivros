using System;

namespace SoLivros.Domain.DTO
{
    using SoLivros.Domain.Infrastructure;
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorDetails { get; set; } = "";
        public bool IsError { get { return !Success; } }

        public BaseResponse(bool success = false, string message = "")
        {
            Success = success;
            Message = message;
        }
    }

    public class BaseResponse<TData> : BaseResponse
        where TData : class
    {
        public TData Data { get; set; }

        public BaseResponse(bool success = false, string message = "", TData data = null) : base(success, message) 
        {
            Data = data;
        }
    }

    public static class BaseResponseExtension
    {
        public static void MontaErro(this BaseResponse response, Exception ex, string erroPadrao = "Houve um erro ao realizar a requisição.")
        {
            response.Success = false;

            if(ex is SoLivrosException)
            {
                response.Message = ex.Message;
                response.ErrorDetails = ex.InnerException?.Message ?? "";
            }
            else
            {
                response.Message = erroPadrao;
                response.ErrorDetails = ex.Message;
            }
        }
    }
}
