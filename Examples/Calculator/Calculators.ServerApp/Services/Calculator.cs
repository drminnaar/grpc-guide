// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: calculator.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Calculators {

  /// <summary>Holder for reflection information generated from calculator.proto</summary>
  public static partial class CalculatorReflection {

    #region Descriptor
    /// <summary>File descriptor for calculator.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CalculatorReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBjYWxjdWxhdG9yLnByb3RvEgtjYWxjdWxhdG9ycyIkChBPcGVyYXRpb25S",
            "ZXF1ZXN0EhAKCG9wZXJhbmRzGAEgAygBIiMKEU9wZXJhdGlvblJlc3BvbnNl",
            "Eg4KBnJlc3VsdBgBIAEoASI0Cg9EaXZpc2lvblJlcXVlc3QSEAoIZGl2aWRl",
            "bmQYASABKAESDwoHZGl2aXNvchgCIAEoASIiChBEaXZpc2lvblJlc3BvbnNl",
            "Eg4KBnJlc3VsdBgBIAEoATKvAgoKQ2FsY3VsYXRvchJECgNBZGQSHS5jYWxj",
            "dWxhdG9ycy5PcGVyYXRpb25SZXF1ZXN0Gh4uY2FsY3VsYXRvcnMuT3BlcmF0",
            "aW9uUmVzcG9uc2USSQoIU3VidHJhY3QSHS5jYWxjdWxhdG9ycy5PcGVyYXRp",
            "b25SZXF1ZXN0Gh4uY2FsY3VsYXRvcnMuT3BlcmF0aW9uUmVzcG9uc2USSQoI",
            "TXVsdGlwbHkSHS5jYWxjdWxhdG9ycy5PcGVyYXRpb25SZXF1ZXN0Gh4uY2Fs",
            "Y3VsYXRvcnMuT3BlcmF0aW9uUmVzcG9uc2USRQoGRGl2aWRlEhwuY2FsY3Vs",
            "YXRvcnMuRGl2aXNpb25SZXF1ZXN0Gh0uY2FsY3VsYXRvcnMuRGl2aXNpb25S",
            "ZXNwb25zZUIOqgILQ2FsY3VsYXRvcnNiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Calculators.OperationRequest), global::Calculators.OperationRequest.Parser, new[]{ "Operands" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Calculators.OperationResponse), global::Calculators.OperationResponse.Parser, new[]{ "Result" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Calculators.DivisionRequest), global::Calculators.DivisionRequest.Parser, new[]{ "Dividend", "Divisor" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Calculators.DivisionResponse), global::Calculators.DivisionResponse.Parser, new[]{ "Result" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class OperationRequest : pb::IMessage<OperationRequest> {
    private static readonly pb::MessageParser<OperationRequest> _parser = new pb::MessageParser<OperationRequest>(() => new OperationRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<OperationRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Calculators.CalculatorReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OperationRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OperationRequest(OperationRequest other) : this() {
      operands_ = other.operands_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OperationRequest Clone() {
      return new OperationRequest(this);
    }

    /// <summary>Field number for the "operands" field.</summary>
    public const int OperandsFieldNumber = 1;
    private static readonly pb::FieldCodec<double> _repeated_operands_codec
        = pb::FieldCodec.ForDouble(10);
    private readonly pbc::RepeatedField<double> operands_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<double> Operands {
      get { return operands_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as OperationRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(OperationRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!operands_.Equals(other.operands_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= operands_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      operands_.WriteTo(output, _repeated_operands_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += operands_.CalculateSize(_repeated_operands_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(OperationRequest other) {
      if (other == null) {
        return;
      }
      operands_.Add(other.operands_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10:
          case 9: {
            operands_.AddEntriesFrom(input, _repeated_operands_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class OperationResponse : pb::IMessage<OperationResponse> {
    private static readonly pb::MessageParser<OperationResponse> _parser = new pb::MessageParser<OperationResponse>(() => new OperationResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<OperationResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Calculators.CalculatorReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OperationResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OperationResponse(OperationResponse other) : this() {
      result_ = other.result_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public OperationResponse Clone() {
      return new OperationResponse(this);
    }

    /// <summary>Field number for the "result" field.</summary>
    public const int ResultFieldNumber = 1;
    private double result_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Result {
      get { return result_; }
      set {
        result_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as OperationResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(OperationResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Result, other.Result)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Result != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Result);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Result != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Result);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Result != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(OperationResponse other) {
      if (other == null) {
        return;
      }
      if (other.Result != 0D) {
        Result = other.Result;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 9: {
            Result = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  public sealed partial class DivisionRequest : pb::IMessage<DivisionRequest> {
    private static readonly pb::MessageParser<DivisionRequest> _parser = new pb::MessageParser<DivisionRequest>(() => new DivisionRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DivisionRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Calculators.CalculatorReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DivisionRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DivisionRequest(DivisionRequest other) : this() {
      dividend_ = other.dividend_;
      divisor_ = other.divisor_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DivisionRequest Clone() {
      return new DivisionRequest(this);
    }

    /// <summary>Field number for the "dividend" field.</summary>
    public const int DividendFieldNumber = 1;
    private double dividend_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Dividend {
      get { return dividend_; }
      set {
        dividend_ = value;
      }
    }

    /// <summary>Field number for the "divisor" field.</summary>
    public const int DivisorFieldNumber = 2;
    private double divisor_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Divisor {
      get { return divisor_; }
      set {
        divisor_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DivisionRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DivisionRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Dividend, other.Dividend)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Divisor, other.Divisor)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Dividend != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Dividend);
      if (Divisor != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Divisor);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Dividend != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Dividend);
      }
      if (Divisor != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Divisor);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Dividend != 0D) {
        size += 1 + 8;
      }
      if (Divisor != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DivisionRequest other) {
      if (other == null) {
        return;
      }
      if (other.Dividend != 0D) {
        Dividend = other.Dividend;
      }
      if (other.Divisor != 0D) {
        Divisor = other.Divisor;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 9: {
            Dividend = input.ReadDouble();
            break;
          }
          case 17: {
            Divisor = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  public sealed partial class DivisionResponse : pb::IMessage<DivisionResponse> {
    private static readonly pb::MessageParser<DivisionResponse> _parser = new pb::MessageParser<DivisionResponse>(() => new DivisionResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DivisionResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Calculators.CalculatorReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DivisionResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DivisionResponse(DivisionResponse other) : this() {
      result_ = other.result_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DivisionResponse Clone() {
      return new DivisionResponse(this);
    }

    /// <summary>Field number for the "result" field.</summary>
    public const int ResultFieldNumber = 1;
    private double result_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Result {
      get { return result_; }
      set {
        result_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DivisionResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DivisionResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Result, other.Result)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Result != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Result);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Result != 0D) {
        output.WriteRawTag(9);
        output.WriteDouble(Result);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Result != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DivisionResponse other) {
      if (other == null) {
        return;
      }
      if (other.Result != 0D) {
        Result = other.Result;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 9: {
            Result = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
