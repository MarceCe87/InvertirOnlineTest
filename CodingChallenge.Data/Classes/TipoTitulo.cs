namespace CodingChallenge.Data.Classes
{
    public class TipoTitulo
    {
        /// <summary>
        /// Identificador numérico del título en DB.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripción del tipo de título.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Descripción en plural del tipo de título.
        /// </summary>
        public string DescripcionPlural { get; set; }
    }

}
