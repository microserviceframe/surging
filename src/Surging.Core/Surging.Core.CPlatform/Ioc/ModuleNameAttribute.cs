using System;

namespace Surging.Core.CPlatform.Ioc
{
    /// <summary>
    /// 模块特性/属性
    /// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ModuleNameAttribute : Attribute
    {
        public string ModuleName { get; set; }

        public string Version { get; set; }

        public ModuleNameAttribute()
        {

        }
        public ModuleNameAttribute(string moduleName)
        {
            ModuleName = moduleName;
        }
    }
}