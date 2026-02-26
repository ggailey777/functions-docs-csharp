using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;

namespace My.Functions
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