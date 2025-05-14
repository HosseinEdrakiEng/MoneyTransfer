using Helper;

namespace Application.Common
{
    public class HangfireConfig : BaseHttpClientConfig
    {
        public string ScheduleUrl { get; set; }
    }
}
