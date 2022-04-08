namespace TreinamentoTDD.API.Domain
{
    public class OperationResult
    {
        public OperationResult(bool success)
        {
            IsSuccessful = success;
        }

        public bool IsSuccessful { get; }
    }
}
