using AdasIt.__cookiecutter.project_name__.Core.Models.Exceptions;
using System.Collections.Generic;

namespace AdasIt.__cookiecutter.project_name__.Core.Models
{
    public class DefaultResponseDto<T>
    {
        public DefaultResponseDto()
        {
            Errors = new List<ErrorModel>();
            ErrorCode = null;
        }

        public DefaultResponseDto(T data)
        {
            Errors = new List<ErrorModel>();
            Data = data;
            ErrorCode = null;
        }

        public DefaultResponseDto(T data, string errorCode)
        {
            Errors = new List<ErrorModel>();
            ErrorCode = errorCode;
            Data = data;
        }

        public DefaultResponseDto(T data, string errorCode, List<ErrorModel> errors)
        {
            Errors = new List<ErrorModel>();
            ErrorCode = errorCode;
            Data = data;
            Errors = errors;
        }

        public DefaultResponseDto(T data, string errorCode, ErrorModel error)
        {
            Errors = new List<ErrorModel>();
            ErrorCode = errorCode;
            Data = data;
            Errors.Add(error);
        }

        public T Data { get; set; }
        public string ErrorCode { get; private set; }
        public List<ErrorModel> Errors { get; private set; }

        public void SetErrorCode(string value)
        {
            ErrorCode = value;
        }
    }
}
