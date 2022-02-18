using Instagram.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCarParking.Manager;
using MyCarParking.Models;
using MyCarParking.ParkContext;
using MyCarParking.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarParking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        myparkingContext context = ContextManager.GetContext();
        adminManager manageadmin = new adminManager();
        private readonly IHttpContextAccessor _httpContextAccessor;
        SessionHelper sessionHelper;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            sessionHelper = new SessionHelper(_httpContextAccessor);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("listele")]
        public IActionResult Listele()
        {
            if (sessionHelper.Get("kullanici_adi") == null)
            {
                return RedirectToAction("Index");
            }
           
            var viewModel = new OtoparkViewModel();
            viewModel.OtoparCarList = context.Carparks.ToList();



            //ViewBag.liste = ;
            return View(viewModel);
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Route("girisYapPost")]
        [HttpPost]
        public bool girisYapPost([FromForm] KullaniciKontrolModel model)
        {

            var user = manageadmin.GetUser(model.username, model.password);
            if (user == null)
            {
                return false;
            }
            else
            {
                sessionHelper.Set("kullanici_adi", model.username);
                sessionHelper.Set("kullanici_id", user.Id);

                return true;

            }
        }




        [Route("cikisyap")]
        [HttpPost]
        public IActionResult logout()
        {
            sessionHelper.Set("kullanici_adi", "");
            return View("Login");

        }

    }

    public class KullaniciKontrolModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}

