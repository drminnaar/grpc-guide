// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: calculator.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Calculators {
  public static partial class Calculator
  {
    static readonly string __ServiceName = "calculators.Calculator";

    static readonly grpc::Marshaller<global::Calculators.OperationRequest> __Marshaller_calculators_OperationRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculators.OperationRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculators.OperationResponse> __Marshaller_calculators_OperationResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculators.OperationResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculators.DivisionRequest> __Marshaller_calculators_DivisionRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculators.DivisionRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Calculators.DivisionResponse> __Marshaller_calculators_DivisionResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Calculators.DivisionResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::Calculators.OperationRequest, global::Calculators.OperationResponse> __Method_Add = new grpc::Method<global::Calculators.OperationRequest, global::Calculators.OperationResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Add",
        __Marshaller_calculators_OperationRequest,
        __Marshaller_calculators_OperationResponse);

    static readonly grpc::Method<global::Calculators.OperationRequest, global::Calculators.OperationResponse> __Method_Subtract = new grpc::Method<global::Calculators.OperationRequest, global::Calculators.OperationResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Subtract",
        __Marshaller_calculators_OperationRequest,
        __Marshaller_calculators_OperationResponse);

    static readonly grpc::Method<global::Calculators.OperationRequest, global::Calculators.OperationResponse> __Method_Multiply = new grpc::Method<global::Calculators.OperationRequest, global::Calculators.OperationResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Multiply",
        __Marshaller_calculators_OperationRequest,
        __Marshaller_calculators_OperationResponse);

    static readonly grpc::Method<global::Calculators.DivisionRequest, global::Calculators.DivisionResponse> __Method_Divide = new grpc::Method<global::Calculators.DivisionRequest, global::Calculators.DivisionResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Divide",
        __Marshaller_calculators_DivisionRequest,
        __Marshaller_calculators_DivisionResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Calculators.CalculatorReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Calculator</summary>
    public partial class CalculatorClient : grpc::ClientBase<CalculatorClient>
    {
      /// <summary>Creates a new client for Calculator</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public CalculatorClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Calculator that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public CalculatorClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected CalculatorClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected CalculatorClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Calculators.OperationResponse Add(global::Calculators.OperationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Add(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Calculators.OperationResponse Add(global::Calculators.OperationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Add, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Calculators.OperationResponse> AddAsync(global::Calculators.OperationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Calculators.OperationResponse> AddAsync(global::Calculators.OperationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Add, null, options, request);
      }
      public virtual global::Calculators.OperationResponse Subtract(global::Calculators.OperationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Subtract(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Calculators.OperationResponse Subtract(global::Calculators.OperationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Subtract, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Calculators.OperationResponse> SubtractAsync(global::Calculators.OperationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SubtractAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Calculators.OperationResponse> SubtractAsync(global::Calculators.OperationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Subtract, null, options, request);
      }
      public virtual global::Calculators.OperationResponse Multiply(global::Calculators.OperationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Multiply(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Calculators.OperationResponse Multiply(global::Calculators.OperationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Multiply, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Calculators.OperationResponse> MultiplyAsync(global::Calculators.OperationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return MultiplyAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Calculators.OperationResponse> MultiplyAsync(global::Calculators.OperationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Multiply, null, options, request);
      }
      public virtual global::Calculators.DivisionResponse Divide(global::Calculators.DivisionRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Divide(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Calculators.DivisionResponse Divide(global::Calculators.DivisionRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Divide, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Calculators.DivisionResponse> DivideAsync(global::Calculators.DivisionRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DivideAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Calculators.DivisionResponse> DivideAsync(global::Calculators.DivisionRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Divide, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override CalculatorClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CalculatorClient(configuration);
      }
    }

  }
}
#endregion