using System;
using System.Threading.Tasks;
using Grpc.Core;

namespace Calculators.ClientApp
{
    internal sealed class Program
    {
        internal static async Task Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50050", ChannelCredentials.Insecure);

            var client = new Calculator.CalculatorClient(channel);
            var operands = new double[5] { 1D, 2D, 3D, 4D, 5D };

            var addRequest = new OperationRequest();
            addRequest.Operands.AddRange(operands);

            var subtractRequest = new OperationRequest();
            subtractRequest.Operands.AddRange(operands);

            var multiplicationRequest = new OperationRequest();
            multiplicationRequest.Operands.AddRange(operands);

            var divisionRequest = new DivisionRequest
            {
                Dividend = 45,
                Divisor = 5
            };

            var sum = await client.AddAsync(addRequest);
            var difference = await client.SubtractAsync(subtractRequest);
            var product = await client.MultiplyAsync(multiplicationRequest);
            var division = await client.DivideAsync(divisionRequest);

            Console.WriteLine($"Sum: {sum.Result}, Difference: {difference.Result}, Product: {product.Result}, Division: {division.Result}");

            await channel.ShutdownAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
