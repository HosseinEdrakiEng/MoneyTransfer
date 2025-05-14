using Application.Models.Hangfire;
using Helper;

namespace Application.Abstraction.IService
{
    public interface IHangfireService
    {
        Task<BaseResponse<ScheduleJobResponseModel>> ScheduleJob(ScheduleJobRequestModel request, CancellationToken cancellationToken);
    }
}
