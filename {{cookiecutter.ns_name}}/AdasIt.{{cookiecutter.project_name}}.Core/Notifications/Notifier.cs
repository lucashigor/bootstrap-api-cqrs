using AdasIt.{{cookiecutter.project_name}}.Core.Models.Exceptions;
using System.Collections.Generic;

namespace AdasIt.{{cookiecutter.project_name}}.Core.Notifications
{
    public class Notifier
    {
        public Notifier()
        {
            Warnings = new List<ErrorModel>();
            Erros = new List<ErrorModel>();
        }

        public string ErrorCode { get; set; }
        public List<ErrorModel> Warnings { get; private set; }
        public List<ErrorModel> Erros { get; private set; }
    }
}
