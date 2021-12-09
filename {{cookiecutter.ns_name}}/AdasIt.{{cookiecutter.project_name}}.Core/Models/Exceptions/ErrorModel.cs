namespace AdasIt.__cookiecutter.project_name__.Core.Models.Exceptions
{
    public class ErrorModel
    {
        public ErrorModel(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; private set; }
        public string Message { get; private set; }
    }
}
