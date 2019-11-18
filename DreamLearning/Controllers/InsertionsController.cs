using DreamLearning.Dto;
using DreamLearning.Models;
using DreamLearning.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DreamLearning.Controllers
{
    public class InsertionsController : Controller
    {
        private MainSqlService mainSqlService = new MainSqlService();

        // GET: Address
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddressPost(HttpPostedFileBase postedFIle, TransData transdata)
        {

            List<Address> addresses = new List<Address>();
            string filepath = string.Empty;
            if (postedFIle != null)
            {
                filepath = Server.MapPath("~/DB/") + Path.GetFileName(postedFIle.FileName);
                string csvData = System.IO.File.ReadAllText(filepath, Encoding.Default);

                int counter = 0;
                foreach (string row in csvData.Split('\n'))
                {
                    if (row != null && row != "" && counter != 0)
                    {
                        Address address = new Address
                        {
                            Inep = Convert.ToString(row.Split(',')[0]),
                            Logradouro = Convert.ToString(row.Split(',')[1]),
                            Numero = Convert.ToString(row.Split(',')[2]),
                            Bairro = Convert.ToString(row.Split(',')[3]),
                            Cep = Convert.ToString(row.Split(',')[4]),
                            Email = Convert.ToString(row.Split(',')[5])
                        };

                        addresses.Add(address);
                        if (counter > 1)
                            mainSqlService.InsertAddress(address, Server.MapPath("~/DB/banco.db"));

                    }
                    counter++;
                }
            }
            transdata.Addresses = addresses;
            return View("Index", "_Layout", transdata);
        }

        [HttpPost]
        public ActionResult SchoolPost(HttpPostedFileBase postedFIle, TransData transdata)
        {

            List<School> schools = new List<School>();
            string filepath = string.Empty;
            if (postedFIle != null)
            {
                filepath = Server.MapPath("~/DB/") + Path.GetFileName(postedFIle.FileName);
                string csvData = System.IO.File.ReadAllText(filepath, Encoding.Default);

                int counter = 0;
                foreach (string row in csvData.Split('\n'))
                {
                    if (row != null && row != "" && counter != 0)
                    {
                        School school = new School
                        {
                            Tipo = Convert.ToString(row.Split(',')[0]),
                            Inep = Convert.ToString(row.Split(',')[1]),
                            Nome = Convert.ToString(row.Split(',')[2]),
                            AbreviacaoNome = Convert.ToString(row.Split(',')[3]),
                            Telefone = Convert.ToString(row.Split(',')[4]),
                        };

                        schools.Add(school);
                        if (counter > 1)
                            mainSqlService.InsertSchool(school, Server.MapPath("~/DB/banco.db"));
                      
                    }
                    counter++;
                }
            }

            transdata.Schools = schools;

            return View("Index", "_Layout", transdata);
        }


        [HttpPost]
        public ActionResult GeolocationPointPost(HttpPostedFileBase postedFIle, TransData transdata)
        {

            List<GeolocationPoint> geolocations = new List<GeolocationPoint>();
            string filepath = string.Empty;
            if (postedFIle != null)
            {


                filepath = Server.MapPath("~/DB/") + Path.GetFileName(postedFIle.FileName);
                string csvData = System.IO.File.ReadAllText(filepath, Encoding.Default);

                int counter = 0;
                foreach (string row in csvData.Split('\n'))
                {
                    if (row != null && row != "" && counter != 0)
                    {
                        GeolocationPoint geolocation = new GeolocationPoint
                        {
                            Inep = Convert.ToString(row.Split(',')[0]),
                            Latitude = Convert.ToString(row.Split(',')[1]),
                            Longitude= Convert.ToString(row.Split(',')[2])

                        };

                        geolocations.Add(geolocation);
                        if (counter > 1)
                            mainSqlService.InsertGeolocation(geolocation, Server.MapPath("~/DB/banco.db"));
                    }
                    counter++;
                }
            }
            transdata.Points = geolocations;
            return View("Index", "_Layout", transdata);
        }
    }
}
