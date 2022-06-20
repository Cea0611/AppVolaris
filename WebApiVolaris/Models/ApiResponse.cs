namespace WebApiVolaris.Models
{
    public class ApiResponse
    {

        public bool IsSuccess { get; set; }

        public string? Message { get; set; }

        public List<FlightModel>? Result { get; set; }
    }
}
