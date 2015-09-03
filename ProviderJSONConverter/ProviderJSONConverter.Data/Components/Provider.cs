using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProviderJSONConverter.Data.Components
{
    public class Provider : IEquatable<Provider>
    {
        public Provider()
        {

        }

        #region provider_vars
        public string npi {get; set;}
        public string type = "INDIVIDUAL";
        public ProviderName name { get; set; }


        [JsonIgnore]
        public Address address { get; set; }
        public List<Address> addresses = new List<Address>(); 
        public string phone { get; set; }
        public List<string> specialty { get; set; }        
        public bool accepting { get; set; }
        public List<ProviderPlan> plans { get; set; }
        public string last_updated_on { get; set; }

        [JsonIgnore]
        public string networks { get; set; }

        [JsonIgnore]
        public string network_type { get; set; }

        [JsonIgnore]
        public string import_type { get; set; }
        #endregion


        public bool addressExists (Address address)
        {
            return this.addresses.Where(x => x.Equals(address)).FirstOrDefault() != null;
        }

        public static bool providerExists(List<Provider> providers, Provider provider)
        {

            return providers.Where(x => x.npi.Equals(provider.npi)).FirstOrDefault() != null;

        }

        public static Provider findProvider(List<Provider> providers, Provider provider)
        {

            return providers.Where(x => x.npi.Equals(provider.npi)).FirstOrDefault();

        }

        public static List<Provider> findProviders(List<Provider> providers, Provider provider)
        {
            return providers.Where(p => p.npi.Equals(provider.npi)).ToList();
        
        }

        public bool Equals(Provider other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return npi.Equals(other.npi)
                && name.first.Equals(other.name.first) 
                && name.last.Equals(other.name.last); 
        }

        public override int GetHashCode()
        {
            int npiHash = npi == null ? 0 : npi.GetHashCode();
            int fNameHash = name.first.GetHashCode();
            int lNameHash = name.last.GetHashCode();

            return npiHash + fNameHash + lNameHash;
        }
    }


}
