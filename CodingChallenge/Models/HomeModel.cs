using CodingChallenge.Data.DataAccess;
using CodingChallenge.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodingChallenge.Data.Classes;
using CodingChallenge.Data.Comunes;

namespace CodingChallenge.Models
{
    public static class HomeModel
    {
        

        /// <summary>
        /// Genera un listado con las descripciones de todos los titulos.
        /// 
        public static List<string> BuscarDescripcionesTitulos()
        {
            List<string> listaDescripciones = new List<string>();
            try
            {               
                listaDescripciones = ObtenerListaTitulos().Select(x => x.Descripcion).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listaDescripciones;
        }

        /// <summary>
        /// Busca el detalle para un titulo determinado.
        /// 
        public static Titulo BuscarDetalleTitulo(string descripcion)
        {
            var detalleTitulo = new Titulo();
            try
            {
                 detalleTitulo = ObtenerListaTitulos().FirstOrDefault(x => x.Descripcion.Equals(descripcion));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return detalleTitulo;
        }


        /// <summary>
        /// Genera un resumen de titulos.
        /// 
        public static string GenerarResumen(Idiomas idioma)
        {
            var resumen = string.Empty;
            try
            {               
                var listaTitulos = ObtenerListaTitulos();
                resumen = Titulo.ImprimirResumen(listaTitulos, idioma);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return resumen;
        }

        private static List<Titulo> ObtenerListaTitulos()
        {
            var listaTitulos = new MockRepository().TituloRepository;
            return listaTitulos.GetTitulos().ToList();
        }

        
    }
}
