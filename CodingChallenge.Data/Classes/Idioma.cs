using System.Collections.Generic;

namespace CodingChallenge.Data.Classes
{
    /// <summary>
    /// Objeto que representa idiomas existenetes en el sistema.
    /// </summary>
    public class Idioma
    {
        /// <summary>
        /// Identificador numérico del idioma en DB.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripción del idioma.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Leyenda que se muestar como titulo del resumen para un idioma determinado.
        /// </summary>
        public List<TipoTitulo> TipoTitulo { get; set; }

        /// <summary>
        /// Leyenda que se muestar como titulo del resumen para un idioma determinado.
        /// </summary>
        public string TituloResumen { get; set; }

        /// <summary>
        /// Leyenda que se muestra cuando el resumen no contenga ningun contenido.
        /// </summary>
        public string LeyendaResumenVacio { get; set; }

        /// <summary>
        /// Leyenda que se muestra para una accion determinada.
        /// </summary>
        public string LeyendaSimbolo { get; set; }

        /// <summary>
        /// Leyenda que se muestra para la cabecera de detalle .
        /// </summary>
        public string LeyendaDetalle { get; set; }
    }

 
}