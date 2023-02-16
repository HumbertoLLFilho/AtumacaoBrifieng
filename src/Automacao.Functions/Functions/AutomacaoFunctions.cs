using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Automacao.Functions
{
    public class AutomacaoFunctions
    {
        private readonly ILogger _logger;

        public AutomacaoFunctions(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AutomacaoFunctions>();
        }

        [FunctionName("AutomacaoFunctions")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
