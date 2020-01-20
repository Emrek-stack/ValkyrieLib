using Valkyrie.Core.Attributes;

namespace Valkyrie.EventBus.Test
{
    [Configuration("AppConfig")]
    public class AppConfig
    {
        public string Name { get; set; }
    }
}