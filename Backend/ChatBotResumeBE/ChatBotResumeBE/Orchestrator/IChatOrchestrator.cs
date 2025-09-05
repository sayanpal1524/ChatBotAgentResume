namespace ChatBotResumeBE.Orchestrator
{
    public interface IChatOrchestrator
    {
        Task<string> HandleMessageAsync(string sessionId, string userMessage);
        IAsyncEnumerable<string> HandleMessageStreamAsync(string sessionId, string userMessage);
    }
}
