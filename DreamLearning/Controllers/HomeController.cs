using CsvHelper;
using DreamLearning.Models;
using DreamLearning.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamLearning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFIle)
        {
            // StreamReader sr = new StreamReader();
            List<Address> addresses = new List<Address>();
            string filepath = string.Empty; 
            if(postedFIle != null)  
            {
                string path = Server.MapPath("~/Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path); 
                }
                filepath = path + Path.GetFileName(postedFIle.FileName);
                string extension = Path.GetExtension(postedFIle.FileName);
                postedFIle.SaveAs(filepath);

                string csvData = System.IO.File.ReadAllText(filepath); 
                foreach(string row in csvData.Split('\n'))
                {
                    if(row != null && row != "")
                    {
                        addresses.Add(new Address
                        {
                            Inep = Convert.ToString(row.Split(',')[0]),
                            Logradouro = Convert.ToString(row.Split(',')[1]),
                            Numero = Convert.ToString(row.Split(',')[2]),
                            Bairro = Convert.ToString(row.Split(',')[3]),
                            Cep = Convert.ToString(row.Split(',')[4])

                        });
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