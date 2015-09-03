using System.ComponentModel;

namespace ProviderJSONConverter.Data.Components
{
    public struct ProviderName
    {
        public string first { get; set; }
        [DefaultValue("")]
        public string middle { get; set; }
        public string last { get; set; }

        [DefaultValue("")]
        public string suffix { get; set; }
    }
}
