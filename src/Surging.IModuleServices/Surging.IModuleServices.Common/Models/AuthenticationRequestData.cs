using ProtoBuf;

namespace Surging.IModuleServices.Common.Models
{
    [ProtoContract]
    public class AuthenticationRequestData
    {
        [ProtoMember(1)]
        public string UserName { get; set; }

        [ProtoMember(2)]
        public string Password { get; set; }
    }
}
