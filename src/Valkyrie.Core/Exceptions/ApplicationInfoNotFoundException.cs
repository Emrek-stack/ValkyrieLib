using System;

namespace Valkyrie.Core.Exceptions
{
    public class ApplicationInfoNotFoundException : CoreException
    {
        public ApplicationInfoNotFoundException(string message) : base(message)
        {
        }

        public ApplicationInfoNotFoundException(string message, Exception innerEx) : base(message, innerEx)
        {
        }
    }
}