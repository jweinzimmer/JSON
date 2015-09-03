using System;
using System.Collections;
using System.ComponentModel;

namespace ProviderJSONConverter.Data.Components
{
    public class Address : IEquatable<Address>
    {
        public string address { get; set; }

        [DefaultValue("")]
        public string address_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

        public bool Equals(Address other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return (this.address.Equals(other.address)
                && this.address_2.Equals(other.address_2)
                && this.city.Equals(other.city)
                && this.state.Equals(other.state)
                && this.zip.Equals(other.zip));
        }

        public Address DeepCopy()
        {
            return new Address
            {
                address = String.Copy(this.address),
                address_2 = String.Copy(this.address_2),
                city = String.Copy(this.city),
                state = String.Copy(this.state),
                zip = String.Copy(this.zip)
            };
        }
    }
}
