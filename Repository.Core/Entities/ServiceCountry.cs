using System;
using System.Collections.Generic;

#nullable disable

namespace ServicesTekus.Core.Entities
{
    public partial class ServiceCountry
    {
        public decimal Id { get; set; }
        public decimal IdService { get; set; }
        public decimal IdCountry { get; set; }
        public bool? Enable { get; set; }

        public virtual Country? IdCountryNavigation { get; set; }
        public virtual Service? IdServiceNavigation { get; set; }
    }
}
