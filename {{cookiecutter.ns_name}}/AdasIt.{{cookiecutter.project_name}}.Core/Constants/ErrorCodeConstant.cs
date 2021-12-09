using AdasIt.__cookiecutter.project_name__.Core.Models.Exceptions;

namespace AdasIt.__cookiecutter.project_name__.Core.Constants
{
    public static class ErrorCodeConstant
    {
        public static readonly ErrorModel Generic = new ("0001", "Unfortunately an error occurred during the processing.");
        public static readonly ErrorModel Validation = new ("0002", "Unfortunately your request do not pass in our validation process.");
        public static readonly ErrorModel ClientHttp = new ("0003", "Unfortunately an error occurred during the external request.");
        public static readonly ErrorModel UnavailableFeatureFlag = new ("0004", "Unfortunately this feature are unavailable.");
    }
}
