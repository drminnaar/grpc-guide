using System;
using System.IO;
using System.Threading.Tasks;
using Grpc.Core;

namespace Calculators.ServerApp
{
    internal sealed class Program
    {
        internal static async Task Main(string[] args)
        {
            const int Port = 50050;

            Server server = null;

            try
            {
                server = new Server
                {
                    Services = { Calculator.BindService(new CalculatorService()) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };

                server.Start();

                Console.WriteLine($"Calculator server listening on port {Port}");
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();
            }
            catch (IOException exception)
            {
                Console.WriteLine($"Server failed to start: {exception.Message}");
                throw;
            }
            finally
            {
                if (server != null)
                    await server.ShutdownAsync();
            }
        }
    }
}
