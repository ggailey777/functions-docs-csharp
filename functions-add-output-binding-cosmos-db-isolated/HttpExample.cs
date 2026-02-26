using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace My.Functions
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

            // Return a response to both HTTP trigger and Azure Cosmos DB output binding.
            return new MultiResponse()
            {
                Document = new MyDocument
                {
                    id = System.Guid.NewGuid().ToString(),
                    message = message
                },
                HttpResponse = new OkObjectResult(message)
            };
        }
    }
    public class MultiResponse
    {
        [CosmosDBOutput("my-database", "my-container",
            Connection = "CosmosDbConnectionSetting", CreateIfNotExists = true)]
        public MyDocument Document { get; set; }
        public IActionResult HttpResponse { get; set; }
    }
    public class MyDocument {
        public string id { get; set; }
        public string message { get; set; }
    }
}
