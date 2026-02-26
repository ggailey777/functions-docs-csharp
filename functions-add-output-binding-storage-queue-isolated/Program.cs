using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;

namespace functions_add_output_binding_storage_queue_isolated
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