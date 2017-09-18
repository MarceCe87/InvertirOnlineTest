using System.Collections.Generic;
using CodingChallenge.Data.Classes;

namespace CodingChallenge.Data.DataAccess
{
    public interface IIdiomasRepository
    {
        /// <summary>
        /// Trae un listado con todos los idiomas.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Idioma> GetIdiomas();

        //Idioma GetTituloById();
    }
}
