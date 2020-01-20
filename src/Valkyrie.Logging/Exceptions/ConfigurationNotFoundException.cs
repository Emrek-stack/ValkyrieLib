using System;

namespace Valkyrie.Logging.Exceptions
{
    public class ConfigurationNotFoundException : Exception
    {
        public ConfigurationNotFoundException(string message) : base(message)
        {

        }
    }
}