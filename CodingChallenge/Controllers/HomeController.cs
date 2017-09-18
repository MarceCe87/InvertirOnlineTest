using CodingChallenge.Data.Comunes;
using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BuscarDescripcionesTitulos()
        {
            try
            {
                var listaDescripciones = HomeModel.BuscarDescripcionesTitulos();

                return Json(new { TodoOk = true, descripciones = listaDescripciones });
            }
            catch
            {
                //ToDo: Log Error
                return Json(new { TodoOk = false });
            }
        }

        
         [HttpPost]
        public ActionResult GenerarResumen(int idiomaSelect)
        {
            try
            {
                
                var resumen = HomeModel.GenerarResumen((Idiomas)idiomaSelect);

                return Json(new { TodoOk = true, resumen = resumen });
            }
            catch
            {
                //ToDo: Log Error
                return Json(new { TodoOk = false });
            }
        }

    }
}
