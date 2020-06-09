using ProtoBuf;
using Surging.Core.CPlatform;

namespace Surging.IModuleServices.Common.Models
{
    [ProtoContract]
    public class IdentityUser : RequestData
    {
        [ProtoMember(1)]
        public string RoleId { get; set; }
    }
}
