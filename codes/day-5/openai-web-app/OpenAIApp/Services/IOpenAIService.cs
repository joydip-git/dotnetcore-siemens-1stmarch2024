namespace OpenAIApp.Services
{
    public interface IOpenAIService
    {
        Task<string> GetCompleteSentence(string text);
        Task<string> GetCompleteSentenceAdvanced(string text);
        Task<string> CheckProgrammingLanguage(string language);
    }
}
