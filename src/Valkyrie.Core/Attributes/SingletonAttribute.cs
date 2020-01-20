using System;
using Valkyrie.Core.Abstractions;

namespace Valkyrie.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SingletonAttribute : Attribute, IAttribute
    {
    }
}
