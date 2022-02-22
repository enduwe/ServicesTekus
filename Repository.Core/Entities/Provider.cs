using System;
using System.Collections.Generic;

#nullable disable

namespace ServicesTekus.Core.Entities
{
    public partial class Provider
    {
        public Provider()
        {
            DynamicFields = new HashSet<DynamicField>();
            Services = new HashSet<Service>();
        }

        public decimal Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DynamicField> DynamicFields { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
