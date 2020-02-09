// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: messaging.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Messaging {
  public static partial class Messenger
  {
    static readonly string __ServiceName = "messaging.Messenger";

    static readonly grpc::Marshaller<global::Messaging.MessageRequest> __Marshaller_messaging_MessageRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Messaging.MessageRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Messaging.MessageResponse> __Marshaller_messaging_MessageResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Messaging.MessageResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Messaging.MessageRequest, global::Messaging.MessageResponse> __Method_Message = new grpc::Method<global::Messaging.MessageRequest, global::Messaging.MessageResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Message",
        __Marshaller_messaging_MessageRequest,
        __Marshaller_messaging_MessageResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Messaging.MessagingReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Messenger</summary>
    [grpc::BindServiceMethod(typeof(Messenger), "BindService")]
    public abstract partial class MessengerBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Messaging.MessageResponse> Message(global::Messaging.MessageRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(MessengerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Message, serviceImpl.Message).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, MessengerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Message, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Messaging.MessageRequest, global::Messaging.MessageResponse>(serviceImpl.Message));
    }

  }
}
#endregion