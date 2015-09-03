using System;

namespace ProviderJSONConverter.Data.Components
{
    public class JSONPlan
    {
        public string plan_id_type;
        public string plan_id;
        public string marketing_name;
        public string summary_url;
        public string plan_contact;
        public NetworkTier[] network;
        public string[] formulary;
        public DateTime last_updated_on;
    }

    public struct NetworkTier
    {
        public string network_tier;
    }
}
