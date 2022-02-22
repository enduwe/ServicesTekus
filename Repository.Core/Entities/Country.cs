using System;
using System.Collections.Generic;

#nullable disable

namespace ServicesTekus.Core.Entities
{
    public partial class Country
    {
        public Country()
        {
            ServiceCountries = new HashSet<ServiceCountry>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ServiceCountry> ServiceCountries { get; set; }
    }
}
