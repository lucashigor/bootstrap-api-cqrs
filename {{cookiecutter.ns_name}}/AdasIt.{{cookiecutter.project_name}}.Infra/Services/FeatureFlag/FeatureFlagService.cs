using AdasIt.{{cookiecutter.project_name}}.Core.Constants;
using AdasIt.{{cookiecutter.project_name}}.Core.Infra.Service;
using AdasIt.{{cookiecutter.project_name}}.Core.Models;
using AdasIt.{{cookiecutter.project_name}}.Core.Models.Exceptions;
using AdasIt.{{cookiecutter.project_name}}.Infra.Services.FeatureFlag.Request;
using Refit;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdasIt.{{cookiecutter.project_name}}.Infra.Services.FeatureFlag
{
    public class FeatureFlagService : IFeatureFlagService
    {
        private static readonly string On = "on";

        private readonly IFeatureFlagClient client;

        public FeatureFlagService(
            IFeatureFlagClient client)
        {
            this.client = client;
        }

        public async Task<bool> IsEnabledAsync(string feature)
        {
            return await IsEnabledAsync(feature, feature, null);
        }

        public async Task<bool> IsEnabledAsync(string key, string feature)
        {
            return await IsEnabledAsync(key, feature, null);
        }

        public async Task<bool> IsEnabledAsync(string key, string feature, Dictionary<string, string> att)
        {
            string treatment = await GetValueAsync(key, feature, att);

            return On.Equals(treatment);
        }

        public async Task<string> GetValueAsync(string key, string feature)
        {
            return await GetValueAsync(key, feature, null);
        }

        public async Task<string> GetValueAsync(string key, string feature, Dictionary<string, string> att)
        {
            var listAtt = new List<KeyValueDto>();

            foreach (var item in att)
            {
                listAtt.Add(new KeyValueDto() { Key = item.Key, Value = item.Value });
            }

            RequestDto requestDto = new(key, feature, listAtt);

            DefaultResponseDto<string> responseDto;

            try
            {
                responseDto = await client.Flags(requestDto);

            }
            catch (ApiException ex)
            {
                try
                {
                    throw new BusinessException(ErrorCodeConstant.UnavailableFeatureFlag, ex);
                }
                catch (JsonException jsonEx)
                {
                    throw new BusinessException(ErrorCodeConstant.ClientHttp, jsonEx);
                }

            }

            return responseDto.Data;
        }
    }
}
