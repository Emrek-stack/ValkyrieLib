namespace Valkyrie.Core.Model
{
    public class ApplicationInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Scope { get; set; }
        public string Environment { get; set; }
        public int CacheInterval { get; set; }
    }
}