using System;
using System.Net;
using System.Net.Mime;
using System.Runtime.Serialization;

namespace AdasIt.__cookiecutter.project_name__.Core.Models.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        [NonSerialized]
        public readonly ErrorModel Error;

        public readonly string ErrorCode;

        public readonly HttpStatusCode StatusCode = HttpStatusCode.InternalServerError;

        public readonly string ContentType = MediaTypeNames.Application.Json;

        public BusinessException(ErrorModel error) : base(error.Message)
        {
            this.ErrorCode = error.Code;
            this.Error = error;
        }

        public BusinessException(string errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
            this.Error = new (errorCode, message);
        }

        public BusinessException(string errorCode, ErrorModel error) : base(error.Message)
        {
            this.ErrorCode = errorCode;
            this.Error = error;
        }
        public BusinessException(ErrorModel error, Exception inner) : base(error.Message, inner)
        {
            this.ErrorCode = error.Code;
            this.Error = error;
        }

        public BusinessException(string errorCode, string message, Exception inner) : base(message, inner)
        {
            this.ErrorCode = errorCode;
            this.Error = new (errorCode, message);
        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
