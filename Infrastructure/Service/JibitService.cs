using Application.Abstraction.IService;
using Application.Common;
using Application.Models.Jibit;
using Helper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Infrastructure.Service
{
    public class JibitService : IJibitService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JibitConfig _jibitConfig;
        private readonly ILogger<JibitService> _logger;

        public JibitService(IHttpClientFactory httpClientFactory
            , IOptions<JibitConfig> jibitConfig
            , ILogger<JibitService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _jibitConfig = jibitConfig.Value;
            _logger = logger;
        }

        private async Task<BaseResponse<GenerateJibitTokenResponseModel>> GenerateToken(CancellationToken cancellationToken)
        {
            var result = new BaseResponse<GenerateJibitTokenResponseModel>();

            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var model = new
            {
                apiKey = _jibitConfig.ApiKey,
                secretKey = _jibitConfig.SecretKey
            };
            var apiResponse = await _httpClientFactory.ApiCall("Jibit", model, HttpMethod.Post, _jibitConfig.GenerateTokenUrl, headers, cancellationToken);
            _logger.LogInformation($"GenerateToken jibit log : '{apiResponse.SerializeAsJson()}'");
            if (!apiResponse.IsSuccessStatusCode
                || string.IsNullOrWhiteSpace(apiResponse.Response))
            {
                result.Error = CustomError.GenerateJibitTokenFail;
                return result;
            }

            result.Data = JsonSerializer.Deserialize<GenerateJibitTokenResponseModel>(apiResponse.Response);
            return result;
        }

        public async Task<BaseResponse<GenerateJibitPayIdResponseModel>> GeneratePayId(GenerateJibitPayIdRequestModel request, CancellationToken cancellationToken)
        {
            var result = new BaseResponse<GenerateJibitPayIdResponseModel>();

            var token = await this.GenerateToken(cancellationToken);
            if (token.HasError)
            {
                result.Error = token.Error;
                return result;
            }

            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Authorization", $"Bearer {token}"}
            };

            var apiResponse = await _httpClientFactory.ApiCall("Jibit", request, HttpMethod.Post, _jibitConfig.GeneratePayIdUrl, headers, cancellationToken);
            _logger.LogInformation($"GeneratePayId jibit log : '{apiResponse.SerializeAsJson()}'");

            if (!apiResponse.IsSuccessStatusCode
                || string.IsNullOrWhiteSpace(apiResponse.Response))
            {
                result.Error = CustomError.GenerateJibitPayIdFail;
                return result;
            }

            result.Data = JsonSerializer.Deserialize<GenerateJibitPayIdResponseModel>(apiResponse.Response);
            return result;
        }

        public async Task<BaseResponse<GenerateJibitPayIdResponseModel>> PayIdInfo(string merchantRefrenceNumber, CancellationToken cancellationToken)
        {
            var result = new BaseResponse<GenerateJibitPayIdResponseModel>();

            var token = await this.GenerateToken(cancellationToken);
            if (token.HasError)
            {
                result.Error = token.Error;
                return result;
            }

            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Authorization", $"Bearer {token}"}
            };

            var apiResponse = await _httpClientFactory.ApiCall("Jibit", new object(), HttpMethod.Get, $"{_jibitConfig.PayIdInfoUrl}/{merchantRefrenceNumber}", headers, cancellationToken);
            _logger.LogInformation($"PayIdInfo jibit log : '{apiResponse.SerializeAsJson()}'");

            if (!apiResponse.IsSuccessStatusCode
                || string.IsNullOrWhiteSpace(apiResponse.Response))
            {
                result.Error = CustomError.JibitPayIdInfoFail;
                return result;
            }

            result.Data = JsonSerializer.Deserialize<GenerateJibitPayIdResponseModel>(apiResponse.Response);
            return result;
        }

        public async Task<BaseResponse<InquiryJibitPayIdResponseModel>> PayIdInquiry(string externalRefrenceNumber, CancellationToken cancellationToken)
        {
            var result = new BaseResponse<InquiryJibitPayIdResponseModel>();

            var token = await this.GenerateToken(cancellationToken);
            if (token.HasError)
            {
                result.Error = token.Error;
                return result;
            }

            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Authorization", $"Bearer {token}"}
            };

            var apiResponse = await _httpClientFactory.ApiCall("Jibit", new object(), HttpMethod.Get, $"{_jibitConfig.PayIdInquiryUrl}/{externalRefrenceNumber}", headers, cancellationToken);
            _logger.LogInformation($"PayIdInquiry jibit log : '{apiResponse.SerializeAsJson()}'");

            if (!apiResponse.IsSuccessStatusCode
                || string.IsNullOrWhiteSpace(apiResponse.Response))
            {
                result.Error = CustomError.JibitPayIdInquiryFail;
                return result;
            }

            result.Data = JsonSerializer.Deserialize<InquiryJibitPayIdResponseModel>(apiResponse.Response);
            return result;
        }

        public async Task<BaseResponse<VerifyJibitPayIdResponseModel>> PayIdVerify(string externalRefrenceNumber, CancellationToken cancellationToken)
        {
            var result = new BaseResponse<VerifyJibitPayIdResponseModel>();

            var token = await this.GenerateToken(cancellationToken);
            if (token.HasError)
            {
                result.Error = token.Error;
                return result;
            }

            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Authorization", $"Bearer {token}"}
            };

            var apiResponse = await _httpClientFactory.ApiCall("Jibit", new object(), HttpMethod.Get, string.Format(_jibitConfig.PayIdVerifyUrl, externalRefrenceNumber), headers, cancellationToken);
            _logger.LogInformation($"PayIdVerify jibit log : '{apiResponse.SerializeAsJson()}'");

            if (!apiResponse.IsSuccessStatusCode
                || string.IsNullOrWhiteSpace(apiResponse.Response))
            {
                result.Error = CustomError.JibitPayIdVerifyFail;
                return result;
            }

            result.Data = JsonSerializer.Deserialize<VerifyJibitPayIdResponseModel>(apiResponse.Response);
            return result;
        }

        public async Task<BaseResponse<FailJibitPayIdResponseModel>> PayIdFail(string externalRefrenceNumber, CancellationToken cancellationToken)
        {
            var result = new BaseResponse<FailJibitPayIdResponseModel>();

            var token = await this.GenerateToken(cancellationToken);
            if (token.HasError)
            {
                result.Error = token.Error;
                return result;
            }

            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Authorization", $"Bearer {token}"}
            };

            var apiResponse = await _httpClientFactory.ApiCall("Jibit", new object(), HttpMethod.Get, string.Format(_jibitConfig.PayIdFailUrl, externalRefrenceNumber), headers, cancellationToken);
            _logger.LogInformation($"PayIdFail jibit log : '{apiResponse.SerializeAsJson()}'");

            if (!apiResponse.IsSuccessStatusCode
                || string.IsNullOrWhiteSpace(apiResponse.Response))
            {
                result.Error = CustomError.JibitPayIdFail;
                return result;
            }

            result.Data = JsonSerializer.Deserialize<FailJibitPayIdResponseModel>(apiResponse.Response);
            return result;
        }
    }
}
