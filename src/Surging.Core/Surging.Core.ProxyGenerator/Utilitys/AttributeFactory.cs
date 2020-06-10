using Surging.Core.ProxyGenerator.FastReflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Surging.Core.ProxyGenerator.Utilitys
{
    class AttributeFactory
    {
        public AttributeFactory(CustomAttributeData data)
        {
            Data = data;

            var ctorInvoker = new ConstructorInvoker(data.Constructor);
            var ctorArgs = data.ConstructorArguments.Select(a => a.Value).ToArray();
            m_attributeCreator = () => ctorInvoker.Invoke(ctorArgs);

            m_propertySetters = new List<Action<object>>();
            foreach (var arg in data.NamedArguments)
            {
                var property = (PropertyInfo)arg.MemberInfo;
                var propertyAccessor = new PropertyAccessor(property);
                var value = arg.TypedValue.Value;
                m_propertySetters.Add(o => propertyAccessor.SetValue(o, value));
            }
        }

        public CustomAttributeData Data { get; private set; }

        private Func<object> m_attributeCreator;

        private List<Action<object>> m_propertySetters;

        public Attribute Create()
        {
            var attribute = m_attributeCreator();

            foreach (var setter in m_propertySetters)
            {
                setter(attribute);
            }

            return (Attribute)attribute;
        }
    }
}
