using System;

namespace Surging.Core.DotNettyWSServer.Attributes
{
    public class BehaviorContractAttribute : Attribute
    {
        public string Protocol { get; set; }
    }
}
