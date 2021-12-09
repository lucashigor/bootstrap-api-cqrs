using System;

namespace AdasIt.{{cookiecutter.project_name}}.Core.Command.Models
{
    public class ConfigurationCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
