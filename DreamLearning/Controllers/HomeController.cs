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
        public ActionResult Index()
        {
            return View();
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