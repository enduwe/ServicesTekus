using ServicesTekus.Core.Entities;
using ServicesTekus.Core.Interface;
using ServicesTekus.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ServicesTekus.Core.DTOs;

namespace ServicesTekus.Repository.Model
{
    public class ServicesTekusRepository : IServicesTekus
    {
        private readonly ServicesTekusContext _context;
        private readonly IMapper _mapper;


        public ServicesTekusRepository(ServicesTekusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Country> GetCountry()
        {
            var countrys = _context.Countries;

            return countrys;
        }

        public IEnumerable<Provider> GetProvider()
        {
            var provider = _context.Providers;

            return provider;
        }

        
        public string SaveService(ServiceDTO servicemodel)
        {
            Service _servicemodel = new Service();
            _servicemodel.IdProvider = servicemodel.IdProvider;
            _servicemodel.Name = servicemodel.Name;
            _servicemodel.PricePerHour = servicemodel.PricePerHour;
            

            var service = _context.Services.Add(_servicemodel);
            _context.SaveChanges();


            ServiceCountry _serviceCountrymodel = new ServiceCountry();
            _serviceCountrymodel.IdCountry = servicemodel.IdCountry;
            _serviceCountrymodel.IdService = _servicemodel.Id;

            var serviceCountries = _context.ServiceCountries.Add(_serviceCountrymodel);
            _context.SaveChanges();

            return "ok";
        }
    }
}
