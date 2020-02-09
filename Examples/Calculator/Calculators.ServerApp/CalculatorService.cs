using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Calculators.ServerApp
{
    public sealed class CalculatorService : Calculator.CalculatorBase
    {
        public override Task<OperationResponse> Add(OperationRequest request, ServerCallContext context)
        {
            return Task.FromResult(new OperationResponse
            {
                Result = request.Operands.Sum()
            });
        }

        public override Task<DivisionResponse> Divide(DivisionRequest request, ServerCallContext context)
        {
            return Task.FromResult(new DivisionResponse
            {
                Result = request.Dividend / request.Divisor
            });
        }

        public override Task<OperationResponse> Multiply(OperationRequest request, ServerCallContext context)
        {
            return Task.FromResult(new OperationResponse
            {
                Result = request.Operands.Aggregate((acc, operand) => acc *= operand)
            });
        }

        public override Task<OperationResponse> Subtract(OperationRequest request, ServerCallContext context)
        {
            return Task.FromResult(new OperationResponse
            {
                Result = request.Operands.Aggregate((acc, operand) => acc -= operand)
            });
        }
    }
}
