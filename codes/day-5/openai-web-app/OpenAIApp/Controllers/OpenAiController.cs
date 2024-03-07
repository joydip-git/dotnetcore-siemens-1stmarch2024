using Microsoft.AspNetCore.Mvc;
using OpenAIApp.Services;

namespace OpenAIApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAiController : Controller
    {
        private readonly ILogger<OpenAiController> logger;
        private readonly IOpenAIService openAIService;

        public OpenAiController(ILogger<OpenAiController> logger, IOpenAIService openAIService)
        {
            this.logger = logger;
            this.openAIService = openAIService;
        }

        [HttpPost]
        [Route("complete")]
        public async Task<IActionResult> Complete(string text)
        {
            //var result = await openAIService.GetCompleteSentence(text);
            var result = await openAIService.GetCompleteSentenceAdvanced(text);
            return Ok(result);
        }

        [HttpPost]
        [Route("askquestion")]
        public async Task<IActionResult> AskAQuestion(string text)
        {
            //var result = await openAIService.GetCompleteSentence(text);
            var result = await openAIService.CheckProgrammingLanguage(text);
            return Ok(result);
        }
    }
}
