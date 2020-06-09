using Surging.Core.CPlatform.Messages;

namespace Surging.Core.CPlatform.Diagnostics
{
    public class DiagnosticMessage : TransportMessage
    {
        public string MessageName { get; set; }
    }
}
