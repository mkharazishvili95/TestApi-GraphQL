namespace TestGraph.Models
{
    public class BaseResponseModel
    {
        public int? StatusCode { get; set; }
        public string? UserMessage { get; set; }
        public bool? Success { get; set; }
    }
}
