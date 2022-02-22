using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesTekus.WebApp.Models
{
    public class ServicesTekusViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public int Id_Provider { get; set; }
        public int Id_Country { get; set; }
    }
}
