using ServicesTekus.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTekus.Core.DTOs
{
    public class ServiceDTO
    {

        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal IdProvider { get; set; }

        public decimal IdCountry { get; set; }
        

        public  ICollection<DynamicField>? dynamicField { get; set; }

    }
}
