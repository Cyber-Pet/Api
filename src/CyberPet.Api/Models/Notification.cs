namespace CyberPet.Api.Models
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }
        public Notification(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string Exception { get; set; }
    }
}
