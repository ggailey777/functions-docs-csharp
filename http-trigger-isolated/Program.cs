using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;

namespace FunctionApp10
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWebApplication()
                .Build();

            host.Run();
        }
    }
}