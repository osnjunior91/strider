namespace Strider.Lib.Strider.Lib.Domain.Queries
{ 
    public class QueryResult
    {
        public object Data { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public QueryResult(bool success, object data = null, string message = null)
        {
            Success = success;
            Data = data;
            Message = message;
        }
    }
}
