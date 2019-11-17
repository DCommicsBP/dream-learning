using CsvHelper;
using DreamLearning.Dto;
using DreamLearning.Models;
using DreamLearning.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace DreamLearning.Controllers
{
    public class HomeController : Controller
    {
        private MainSqlService sqlService = new MainSqlService();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllData()
        {
            string path = Server.MapPath("~/DB/banco.db");
            List<GeolocationPoint> geolocationPoints = new List<GeolocationPoint>();
            List<School> schools = new List<School>();
            List<Address> adresses = new List<Address>();

            geolocationPoints = sqlService.GeolocationPoints(path);
            schools = sqlService.GetSchools(path);
            adresses = sqlService.GetAddresses(path);

            TransData transdata = new TransData();
            transdata.Addresses = adresses;
            transdata.Schools = schools;
            transdata.Points = geolocationPoints;

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(js);
            ViewBag.Data = json;
            return Json(transdata, JsonRequestBehavior.AllowGet); ;
        }

    }
}