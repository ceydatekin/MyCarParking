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
    public class ParkController : ControllerBase
    {
        parkManager managepark = new parkManager();
        tenantManager managetenant = new tenantManager();

        [HttpPost]
        [Route("API/carpark/addcar")]
        public string ParkEkle([FromForm] modelParkEtme model)
        {
            Tenant user = managetenant.Kullanicigisinigetir(model.carplate);
            if (parkManager.ShowCount() <= 5 && user != null)
            {
                DateTime dt = DateTime.Now;
                var label1 = dt.ToLongTimeString();
                var textBox1 = DateTime.Today.ToString();
               // DateTime Tarih = DateTime.Today;
               // textBox1.Text = Tarih.ToShortDateString();
                textBox1 = dt.ToLongDateString();

                managepark.Insert(new Carpark()
                {

                    Carplate = model.carplate,
                    Start = textBox1
                });
                parkManager.AddCount();
                return JsonConvert.SerializeObject(new { success = true, message = "Tebrikler" });
            }
            return "";

        }

        [HttpPost]
        [Route("API/carpark/deletecar")]
        public string ParkCikis([FromForm] modelParkCikisi model)
        {

            Carpark deneme = managepark.Aracbilgisinigetir(model.carplate);
            managepark.Delete(deneme);
            parkManager.DeleteCount();
            return JsonConvert.SerializeObject(new { success = true, message = "Tebrikler" });


        }

        public class modelParkEtme
        {
            public string carplate { get; set; }
            public string saat { get; set; }

        }
        public class modelParkCikisi
        {
            public string carplate { get; set; }
            public string saat { get; set; }

        }



        [HttpGet]
        [Route("api/listele")]
        public string derslistele([FromForm] modellistele model)
        {
            myparkingContext context = ContextManager.GetContext();
            var list = (from _car in context.Carparks
                        join _tenants in context.Tenants on _car.Carplate equals _tenants.Plate

                        select new
                        {
                            Carplate = _car.Carplate,
                            Username = _tenants.Name + " " + _tenants.Surname,
                            Saat = _car.Start
                        }).ToList();
            // context.Dispose();

            return JsonConvert.SerializeObject(new { success = true, message = "Tebirkler", data = list });
        }

        [HttpGet]
        [Route("api/harflelistele")]
        public string harflelistele(string harf)
        {
            parkManager managepark = new parkManager();
            myparkingContext context = ContextManager.GetContext();
            var l = managepark.PlakaSorgulama(harf);
            var liste = new List<Carpark>();
            if (l.Count > 0)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    var og = l[i];
                    var car = managepark.Aracbilgisinigetir(og.Carplate);
                    liste.Add(new Carpark()
                    {
                        Id = car.Id,
                        Carplate = car.Carplate,
                        Start = car.Start
                    }); ;

                }

                var deneme = (from _car in context.Carparks
                              join _tenants in context.Tenants on _car.Carplate equals _tenants.Plate

                              select new
                              {
                                  Carplate = _car.Carplate,
                                  Username = _tenants.Name + " " + _tenants.Surname,
                                  Saat = _car.Start
                              }).ToList();

                return JsonConvert.SerializeObject(new { success = true, message = "Tebirkler", data = deneme });

            }
            else
                return JsonConvert.SerializeObject(new { success = false, message = "Hata", data = "" });
        }


    }
    public class modellistele
    {
        public string Carplate { get; set; }
        public string Saat { get; set; }
        public string Username { get; set; }
    }
}

