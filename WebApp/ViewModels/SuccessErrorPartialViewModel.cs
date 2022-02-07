namespace WebApp.ViewModels
{
    public class SuccessErrorPartialViewModel
    {
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }

    public enum MessageType
    {
        Success, Error
    }
}
