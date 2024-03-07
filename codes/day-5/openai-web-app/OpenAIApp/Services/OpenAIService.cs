using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAIApp.Configurations;

namespace OpenAIApp.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly OpenAiConfig _config;

        public OpenAIService(IOptionsMonitor<OpenAiConfig> config)
        {
            _config = config.CurrentValue;
        }

        public async Task<string> CheckProgrammingLanguage(string language)
        {
            var api = new OpenAIAPI(_config.Key);
            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage("You are tutor, who helps new programmers to understand things are programming language. If an user tells you a thing, respone with yes, if it is a programming language and respond with no if the thing is not a programming language.");
            chat.AppendUserInput(language);
            return await chat.GetResponseFromChatbotAsync();
        }

        public async Task<string> GetCompleteSentence(string text)
        {
            var api = new OpenAIAPI(_config.Key);
            return await api.Completions.GetCompletion(text);
        }

        public async Task<string> GetCompleteSentenceAdvanced(string text)
        {
            var api = new OpenAIAPI(_config.Key);
            var result = await api.Completions.CreateCompletionAsync(
                new CompletionRequest(
                    text, 
                    model: Model.ChatGPTTurbo, 
                    temperature: 0.1)
                );
            return result.Completions[0].Text;
        }
    }
}
