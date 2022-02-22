using System;
using System.Collections.Generic;

#nullable disable

namespace ServicesTekus.Core.Entities
{
    public partial class Service
    {
        public Service()
        {
            ServiceCountries = new HashSet<ServiceCountry>();
        }

        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal IdProvider { get; set; }

        public virtual Provider IdProviderNavigation { get; set; }
        public virtual ICollection<ServiceCountry> ServiceCountries { get; set; }
    }
}
