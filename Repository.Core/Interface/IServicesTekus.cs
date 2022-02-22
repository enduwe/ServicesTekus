using ServicesTekus.Core.DTOs;
using ServicesTekus.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTekus.Core.Interface
{
   public  interface IServicesTekus
    {

        IEnumerable<Country> GetCountry();

        IEnumerable<Provider> GetProvider();

        string SaveService(ServiceDTO servicemodel);
    }
}
