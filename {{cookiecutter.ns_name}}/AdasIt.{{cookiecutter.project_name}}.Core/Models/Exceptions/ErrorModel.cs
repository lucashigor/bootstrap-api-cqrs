namespace AdasIt.{{cookiecutter.project_name}}.Core.Models.Exceptions
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
