using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace functions_add_output_binding_storage_queue_isolated
{
    public class HttpExample
    {
        private readonly ILogger<HttpExample> _logger;

        public HttpExample(ILogger<HttpExample> logger)
        {
            _logger = logger;
        }

        [Function("HttpExample")]
        public MultiResponse Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var message = "Welcome to Azure Functions!";

            // Return a response to both HTTP trigger and storage output binding.
            return new MultiResponse()
            {
                // Write a single message.
                Messages = new string[] { message },
                HttpResponse = new OkObjectResult(message)
            };
        }
    }
    public class MultiResponse
    {
        [QueueOutput("outqueue", Connection = "AzureWebJobsStorage")]
        public string[] Messages { get; set; }
        public IActionResult HttpResponse { get; set; }
    }
}
