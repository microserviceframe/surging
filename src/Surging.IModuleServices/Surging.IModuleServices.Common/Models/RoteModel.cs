using ProtoBuf;

namespace Surging.IModuleServices.Common.Models
{
    [ProtoContract]
    public class RoteModel
    {
        [ProtoMember(1)]
        public string ServiceId { get; set; }
    }
}
