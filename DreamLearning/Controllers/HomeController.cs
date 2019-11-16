using CsvHelper;
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
    public class HomeController : Controller
    {
        private MainSqlService mainSqlService = new MainSqlService();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressPost(HttpPostedFileBase postedFIle)
        {
            
            List<Address> addresses = new List<Address>();
            string filepath = string.Empty;
            if (postedFIle != null)
            {
                filepath =Server.MapPath("~/DB/") + Path.GetFileName(postedFIle.FileName);
                string csvData = System.IO.File.ReadAllText(filepath, Encoding.Default);
            
                int counter = 0; 
                foreach (string row in csvData.Split('\n'))
                {
                    if (row != null && row != "")
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
                        if(counter > 1)
                            mainSqlService.InsertAddress(address, Server.MapPath("~/DB/banco.db"));
                        counter++; 
                    }
                }
            }
            
            return View(addresses);
        }

        [HttpPost]
        public ActionResult SchoolPost(HttpPostedFileBase postedFIle)
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
                    if (row != null && row != "")
                    {
                        School school = new School
                        {
                            Tipo = Convert.ToString(row.Split(',')[0]),
                            Inep = Convert.ToString(row.Split(',')[1]),
                            Nome = Convert.ToString(row.Split(',')[2]),
                            AbreviacaoNome= Convert.ToString(row.Split(',')[3]),
                            Telefone = Convert.ToString(row.Split(',')[4]),

                        };

                        schools.Add(school);
                        if (counter > 1)
                            mainSqlService.InsertSchool(school, Server.MapPath("~/DB/banco.db"));
                        counter++;
                    }
                }
            }

            return View(schools);
        }


        [HttpPost]
        public ActionResult GeolocationPointPost(HttpPostedFileBase postedFIle)
        {

            List<GeolocationPoint> addresses = new List<GeolocationPoint>();
            string filepath = string.Empty;
            if (postedFIle != null)
            {


                filepath = Server.MapPath("~/DB/") + Path.GetFileName(postedFIle.FileName);
                string csvData = System.IO.File.ReadAllText(filepath, Encoding.Default);

                int counter = 0;
                foreach (string row in csvData.Split('\n'))
                {
                    if (row != null && row != "")
                    {
                        GeolocationPoint geolocation = new GeolocationPoint
                        {
                            Inep = Convert.ToString(row.Split(',')[0]),
                            Longitude = Convert.ToString(row.Split(',')[1]),
                            Latitude = Convert.ToString(row.Split(',')[2])
                            
                        };

                        addresses.Add(geolocation);
                        if (counter > 1)
                            mainSqlService.InsertGeolocation(geolocation, Server.MapPath("~/DB/banco.db"));
                        counter++;
                    }
                }
            }

            return View(addresses);
        }

        public ActionResult Teste()
        {
            string path = Server.MapPath("//DB//banco.db");
            MainSqlService mainService = new MainSqlService();
            mainService.CreateDatabase(path);
            return View();

        }

    }
}