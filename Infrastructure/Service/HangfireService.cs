using Application.Abstraction.IService;
using Application.Common;
using Application.Models.Hangfire;
using Helper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Service
{
    public class HangfireService : IHangfireService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HangfireService> _logger;
        private readonly HangfireConfig _hangfireConfig;

        public HangfireService(IHttpClientFactory httpClientFactory
            , IOptions<HangfireConfig> hangfireConfig
            , ILogger<HangfireService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _hangfireConfig = hangfireConfig.Value;
            _logger = logger;
        }

        public async Task<BaseResponse<ScheduleJobResponseModel>> ScheduleJob(ScheduleJobRequestModel request, CancellationToken cancellationToken)
        {
            var result = new BaseResponse<ScheduleJobResponseModel>();

            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" }
            };
            var apiResponse = await _httpClientFactory.ApiCall("Hangfire", request, HttpMethod.Post, _hangfireConfig.ScheduleUrl, headers, cancellationToken);
            _logger.LogInformation($"ScheduleJob log : '{apiResponse.SerializeAsJson()}'");

            if (!apiResponse.IsSuccessStatusCode)
            {
                result.Error = CustomError.ScheduleJobFail;
                return result;
            }

            return result;
        }
    }
}
