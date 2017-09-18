using CodingChallenge.Data.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.DataAccess
{
    public class ContextoDBIdiomas
    {
        private const string JsonIdiomas = "\\ListaIdiomas.json";

        public List<Idioma> GetIdiomas()
        {
            var json = File.ReadAllText(Directory.GetCurrentDirectory() + JsonIdiomas);
            return JsonConvert.DeserializeObject<List<Idioma>>(json).ToList();
        }
    }
}
