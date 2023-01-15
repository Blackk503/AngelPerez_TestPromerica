namespace Core.Interfaces.CustomOperation
{
    public interface IOperationResult<T>
    {
        string Message { get; }
        bool Success { get; }
        T Entity { get; }
        string MessageDetail { get; }
    }
}
