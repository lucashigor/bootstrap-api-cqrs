using System.Collections.Generic;

namespace AdasIt.{{cookiecutter.project_name}}.Infra.Services.FeatureFlag.Request
{
    public class RequestDto
    {

        public RequestDto()
        {
            KeyValues = new List<KeyValueDto>();
        }

        public RequestDto(string key, string featureName) : base()
        {
            this.Key = key;
            this.FeatureName = featureName;
        }

        public RequestDto(string key, string featureName, List<KeyValueDto> keyValues) : base ()
        {
            this.Key = key;
            this.FeatureName = featureName;
            this.KeyValues.AddRange(keyValues);
        }

        public string Key { get; private set; }
        public string FeatureName { get; private set; }
        public List<KeyValueDto> KeyValues { get; private set; }
    }
}
