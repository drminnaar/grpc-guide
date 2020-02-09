using Grpc.Core;
using Messaging;
using System;
using System.Threading.Tasks;

namespace Messaging.ClientApp
{
    internal sealed class Program
    {
        internal static async Task Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50050", ChannelCredentials.Insecure);

            var client = new Messenger.MessengerClient(channel);
            var reply = client.Message(new MessageRequest { Message = "These are not the droids you are looking for ..." });
            Console.WriteLine("Message: " + reply.Message);

            await channel.ShutdownAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
