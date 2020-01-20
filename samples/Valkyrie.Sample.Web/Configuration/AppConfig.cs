using Valkyrie.Core.Attributes;

namespace Valkyrie.Sample.Web.Configuration
{
    [Configuration("AppConfig")]
    public class AppConfig
    {
        public string Name { get; set; }
    }
}