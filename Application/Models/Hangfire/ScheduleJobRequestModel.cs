namespace Application.Models.Hangfire
{
    public class ScheduleJobRequestModel
    {
        public string Url { get; set; }
        public object Model { get; set; }
        public HttpMethod HttpMethod { get; set; } = HttpMethod.Post;
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string> { { "Content-Type", "application/json" } };
        public DateTime EnqueueAt { get; set; }
    }
    public class ScheduleJobResponseModel
    {
    }
}
