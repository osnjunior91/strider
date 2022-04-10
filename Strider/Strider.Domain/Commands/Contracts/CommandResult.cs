namespace Strider.Domain.Commands.Contracts
{
    public class CommandResult
    {
        public object Data { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public CommandResult(bool success, object data = null, string message = null)
        {
            Success = success;
            Data = data;
            Message = message;
        }
    }
}
