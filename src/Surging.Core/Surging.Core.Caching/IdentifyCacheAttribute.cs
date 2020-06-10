using System;

namespace Surging.Core.Caching
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class IdentifyCacheAttribute : Attribute
    {
        public IdentifyCacheAttribute(CacheTargetType name)
        {
            Name = name;
        }

        public CacheTargetType Name { get; set; }
    }
}
