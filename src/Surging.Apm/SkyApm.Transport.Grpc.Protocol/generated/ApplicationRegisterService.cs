// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: language-agent/ApplicationRegisterService.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SkyWalking.NetworkProtocol {

  /// <summary>Holder for reflection information generated from language-agent/ApplicationRegisterService.proto</summary>
  public static partial class ApplicationRegisterServiceReflection {

    #region Descriptor
    /// <summary>File descriptor for language-agent/ApplicationRegisterService.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ApplicationRegisterServiceReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ci9sYW5ndWFnZS1hZ2VudC9BcHBsaWNhdGlvblJlZ2lzdGVyU2VydmljZS5w",
            "cm90bxoobGFuZ3VhZ2UtYWdlbnQvS2V5V2l0aEludGVnZXJWYWx1ZS5wcm90",
            "byImCgtBcHBsaWNhdGlvbhIXCg9hcHBsaWNhdGlvbkNvZGUYASABKAkiPwoS",
            "QXBwbGljYXRpb25NYXBwaW5nEikKC2FwcGxpY2F0aW9uGAEgASgLMhQuS2V5",
            "V2l0aEludGVnZXJWYWx1ZTJcChpBcHBsaWNhdGlvblJlZ2lzdGVyU2Vydmlj",
            "ZRI+ChdhcHBsaWNhdGlvbkNvZGVSZWdpc3RlchIMLkFwcGxpY2F0aW9uGhMu",
            "QXBwbGljYXRpb25NYXBwaW5nIgBCUQowb3JnLmFwYWNoZS5za3l3YWxraW5n",
            "LmFwbS5uZXR3b3JrLmxhbmd1YWdlLmFnZW50UAGqAhpTa3lXYWxraW5nLk5l",
            "dHdvcmtQcm90b2NvbGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::SkyWalking.NetworkProtocol.KeyWithIntegerValueReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SkyWalking.NetworkProtocol.Application), global::SkyWalking.NetworkProtocol.Application.Parser, new[]{ "ApplicationCode" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SkyWalking.NetworkProtocol.ApplicationMapping), global::SkyWalking.NetworkProtocol.ApplicationMapping.Parser, new[]{ "Application" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Application : pb::IMessage<Application> {
    private static readonly pb::MessageParser<Application> _parser = new pb::MessageParser<Application>(() => new Application());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Application> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SkyWalking.NetworkProtocol.ApplicationRegisterServiceReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Application() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Application(Application other) : this() {
      applicationCode_ = other.applicationCode_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Application Clone() {
      return new Application(this);
    }

    /// <summary>Field number for the "applicationCode" field.</summary>
    public const int ApplicationCodeFieldNumber = 1;
    private string applicationCode_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ApplicationCode {
      get { return applicationCode_; }
      set {
        applicationCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Application);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Application other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ApplicationCode != other.ApplicationCode) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (ApplicationCode.Length != 0) hash ^= ApplicationCode.GetHashCode();
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
      if (ApplicationCode.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ApplicationCode);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (ApplicationCode.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ApplicationCode);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Application other) {
      if (other == null) {
        return;
      }
      if (other.ApplicationCode.Length != 0) {
        ApplicationCode = other.ApplicationCode;
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
          case 10: {
            ApplicationCode = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ApplicationMapping : pb::IMessage<ApplicationMapping> {
    private static readonly pb::MessageParser<ApplicationMapping> _parser = new pb::MessageParser<ApplicationMapping>(() => new ApplicationMapping());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ApplicationMapping> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SkyWalking.NetworkProtocol.ApplicationRegisterServiceReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ApplicationMapping() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ApplicationMapping(ApplicationMapping other) : this() {
      application_ = other.application_ != null ? other.application_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ApplicationMapping Clone() {
      return new ApplicationMapping(this);
    }

    /// <summary>Field number for the "application" field.</summary>
    public const int ApplicationFieldNumber = 1;
    private global::SkyWalking.NetworkProtocol.KeyWithIntegerValue application_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SkyWalking.NetworkProtocol.KeyWithIntegerValue Application {
      get { return application_; }
      set {
        application_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ApplicationMapping);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ApplicationMapping other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Application, other.Application)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (application_ != null) hash ^= Application.GetHashCode();
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
      if (application_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Application);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (application_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Application);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ApplicationMapping other) {
      if (other == null) {
        return;
      }
      if (other.application_ != null) {
        if (application_ == null) {
          Application = new global::SkyWalking.NetworkProtocol.KeyWithIntegerValue();
        }
        Application.MergeFrom(other.Application);
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
          case 10: {
            if (application_ == null) {
              Application = new global::SkyWalking.NetworkProtocol.KeyWithIntegerValue();
            }
            input.ReadMessage(Application);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
