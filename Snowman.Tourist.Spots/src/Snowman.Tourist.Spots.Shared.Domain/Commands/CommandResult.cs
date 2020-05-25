namespace Snowman.Tourist.Spots.Shared.Domain.Commands
{
    public sealed class CommandResult
    {
        public CommandResult(bool success)
        {
            Success = success;
        }

        public CommandResult(bool success, object data) : this(success)
        {
            Data = data;
        }

        public CommandResult(bool success, string message) : this(success)
        {
            Message = message;
        }

        public CommandResult(bool success, object data, string message) : this(success, data)
        {
            Message = message;
        }

        public bool Success { get; private set; }
        public object Data { get; private set; }
        public string Message { get; private set; }

        public bool HasAProblem => !Success;

        public void SetData(object data) => Data = data;
    }
}