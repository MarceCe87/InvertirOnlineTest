using CodingChallenge.Data.Comunes;
using CodingChallenge.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    /// <summary>
    /// Objeto que representa títulos pertenecientes al Mercado de Valores argentino.
    /// </summary>
    public class Titulo
    {
        /// <summary>
        /// Identificador numérico del título en DB.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Serie única de letras asignadas a una especie para su operatoria en la bolsa.
        /// </summary>
        public string Simbolo { get; set; }

        /// <summary>
        /// Descripción del papel.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Detalle de la empresa a la que pertenece la acción o bien la denominación del bono.
        /// </summary>
        public string Detalle { get; set; }

        /// <summary>
        /// Tipo de título de la especie en cuestión.
        /// </summary>
        public TiposTitulo Tipo { get; set; }

        /// <summary>
        /// Moneda en la cual se opera el papel.
        /// </summary>
        public Moneda Moneda { get; set; }

        /// <summary>
        /// Devuelve un resumen genérico con datos del título en formato HTML para mostrar en una vista. 
        /// 
        /// TODO:   Refactor. Qué pasaría si tuviera otro tipo de título en el listado además de Accion/Bono? 
        ///         Y si quiero imprimir en otro idioma?
        /// </summary>
        public static string ImprimirResumen(IList<Titulo> titulos, Idiomas idiomaSelect)
        {
            var returnString = new StringBuilder();

            var contexto = new ContextoDBIdiomas();
            var idioma = contexto.GetIdiomas().Single(x => x.Id == (int)idiomaSelect);

            if (!titulos.Any())
            {            
                returnString.Append(string.Format("<h1>{0}</h1>", idioma.LeyendaResumenVacio));
            }
            else
            {

                returnString.Append(string.Format("<h1>{0}</h1>", idioma.TituloResumen));

                foreach (var id in Enum.GetValues(typeof(TiposTitulo)))
                {                    
                    var lista = titulos.Where(x => x.Tipo == (TiposTitulo)id).ToList();
                    if (lista.Count > 0)
                    {
                        var tipoTitulo = idioma.TipoTitulo.Single(x => x.Id == (int)id);

                        var descripcionTipo = string.Empty;
                        if (lista.Count > 1)
                            descripcionTipo = tipoTitulo.DescripcionPlural;
                        else
                            descripcionTipo = tipoTitulo.Descripcion;

                        returnString.Append($"{idioma.LeyendaDetalle} {lista.Count} {descripcionTipo}<br/><br/>");

                        foreach (var titulo in lista)
                        {
                            returnString.Append($"<span>{idioma.LeyendaSimbolo} {tipoTitulo.Descripcion}: {titulo.Simbolo}</span><br/>");
                        }
                        returnString.Append("<br/>");

                    }
                }
            }               
            
            return returnString.ToString();
        }
    }
}