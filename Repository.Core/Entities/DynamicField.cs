using System;
using System.Collections.Generic;

#nullable disable

namespace ServicesTekus.Core.Entities
{
    public partial class DynamicField
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public decimal IdProvider { get; set; }
        public bool? Enable { get; set; }

        public virtual Provider IdProviderNavigation { get; set; }
    }
}
