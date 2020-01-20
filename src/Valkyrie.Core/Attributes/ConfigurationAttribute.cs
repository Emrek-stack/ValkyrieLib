using System;
using Valkyrie.Core.Abstractions;

namespace Valkyrie.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ConfigurationAttribute : Attribute, IAttribute
    {
        public string Section { get; }

        public ConfigurationAttribute(string section)
        {
            Section = section;
        }
    }
}
