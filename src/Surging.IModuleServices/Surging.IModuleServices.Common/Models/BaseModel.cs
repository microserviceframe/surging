using ProtoBuf;
using System;

namespace Surging.IModuleServices.Common.Models
{
    [ProtoContract]
    public class BaseModel
    {
        [ProtoMember(1)]
        public Guid Id => Guid.NewGuid();
    }
}
