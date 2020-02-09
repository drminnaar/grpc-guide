using System.Threading.Tasks;
using Grpc.Core;

namespace Messaging.ServerApp
{
    public sealed class MessengerService : Messenger.MessengerBase
    {
        public override Task<MessageResponse> Message(MessageRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MessageResponse
            {
                Message = $"This is your friendly gRPC Server. Received message: '{request.Message}'"
            });
        }
    }
}