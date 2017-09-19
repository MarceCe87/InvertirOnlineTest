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
        private const string JsonIdiomas = ".Data\\ListaIdiomas.json";

        public List<Idioma> GetIdiomas()
        {
            string exePath = $"{Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)}{JsonIdiomas}";
            var json = File.ReadAllText(exePath);
            return JsonConvert.DeserializeObject<List<Idioma>>(json).ToList();
        }
    }
}
