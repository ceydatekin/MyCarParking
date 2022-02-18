using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCarParking.Manager;
using MyCarParking.ParkContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarParking.APIControllers
{

    [ApiController]
    public class TenantController : ControllerBase
    {
        tenantManager managetenant = new tenantManager();

        [HttpPost]
        [Route("API/addcar")]
        public string ParkEkle([FromForm] modelYeniAraba model)
        {

            {
                managetenant.Insert(new Tenant()
                {
                    Name = model.name,
                    Surname = model.surname,
                    Plate = model.plate


                });
                parkManager.AddCount();
                return JsonConvert.SerializeObject(new { success = true, message = "Tebrikler" });

            }
        }

        public class modelYeniAraba
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string plate { get; set; }

        }

    }
}
