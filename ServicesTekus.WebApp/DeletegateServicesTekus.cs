using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ServicesTekus.Core.DTOs;
using ServicesTekus.Core.Entities;
using ServicesTekus.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTekus.WebApp
{
    public static class DeletegateServicesTekus
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<SelectListItem>> GetCountry()
        {
            IEnumerable<Country> Countrys;
            List<SelectListItem> ListCountry =new List<SelectListItem>(); 

            var UriApi = "https://localhost:44358/api/ServicesTekus/GetCountry/";

            using (var http = new HttpClient())        
            {
                var response = await http.GetStringAsync(UriApi);
                Countrys = JsonConvert.DeserializeObject<IEnumerable<Country>>(response);

                foreach (Country nodo  in Countrys)
                {
                    ListCountry.Add(
                        new SelectListItem()
                        {
                            Value = nodo.Id.ToString(),
                            Text = nodo.Name
                        }
                        );
                }
            }

            return ListCountry;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<SelectListItem>> GetProvider()
        {
            IEnumerable<Provider> Providers;
            List<SelectListItem> ListProvider = new List<SelectListItem>();

            var UriApi = "https://localhost:44358/api/ServicesTekus/GetProvider/";

            using (var http = new HttpClient())
            {
                var response = await http.GetStringAsync(UriApi);
                Providers = JsonConvert.DeserializeObject<IEnumerable<Provider>>(response);

                foreach (Provider nodo in Providers)
                {
                    ListProvider.Add(
                        new SelectListItem()
                        {
                            Value = nodo.Id.ToString(),
                            Text = nodo.Name
                        }
                        );
                }
            }

            return ListProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        public static async Task SaveServiceAsync(ServicesTekusViewModel modelService)
        {
            ServiceDTO entityService = new ServiceDTO();

            var UriApi = "https://localhost:44358/api/ServicesTekus/SaveService/";


            entityService.IdProvider = modelService.Id_Provider;
            entityService.IdCountry = modelService.Id_Country;
            entityService.Name = modelService.Name;
            entityService.PricePerHour = modelService.Price;


            using (var http = new HttpClient())
            {
                var response = await http.PostAsync(UriApi, new StringContent(JsonConvert.SerializeObject(entityService), Encoding.UTF8, "application/json"));
                var result= response.EnsureSuccessStatusCode();


            }


        }



    }
}
