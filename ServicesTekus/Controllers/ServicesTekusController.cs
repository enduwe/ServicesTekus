using Microsoft.AspNetCore.Mvc;
using ServicesTekus.Core.DTOs;
using ServicesTekus.Core.Entities;
using ServicesTekus.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesTekus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesTekusController : ControllerBase
    {
        private readonly IServicesTekus _servicesTekusRepository;
        public ServicesTekusController(IServicesTekus servicesTekusRepository)
        {
            _servicesTekusRepository = servicesTekusRepository;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filters"></param>
        /// <returns></returns>
        [HttpGet("GetCountry")]
        public ActionResult<List<Country>> GetCountry()
        {

            var Country = _servicesTekusRepository.GetCountry();
            return Country.ToList();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filters"></param>
        /// <returns></returns>
        [HttpGet("GetProvider")]
        public ActionResult<List<Provider>> GetProvider()
        {

            var Provider = _servicesTekusRepository.GetProvider();
            return Provider.ToList();
        }

        [HttpPost("SaveService")]
        public ActionResult SaveService(ServiceDTO servicemodel)
        {
            var Service = _servicesTekusRepository.SaveService(servicemodel);

            return Ok();

        }

    }
}
