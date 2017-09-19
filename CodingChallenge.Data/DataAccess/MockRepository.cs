using System.Collections.Generic;
using System.IO;
using CodingChallenge.Data.Classes;
using Moq;
using Newtonsoft.Json;
using System;

namespace CodingChallenge.Data.DataAccess
{
    /// <summary>
    /// Clase repositorio que contiene los accesos a la (mockeada) DB.
    /// </summary>
    public class MockRepository
    {
        private const string JsonTitulos = ".Data\\ListaTitulos.json";        

        /// <summary>
        /// Para utilizar los métodos de acceso a Título.
        /// </summary>
        public ITitulosRepository TituloRepository{ get; set; }

        public MockRepository()
        {
            var mockRepository = new Mock<ITitulosRepository>();

            string exePath = $"{Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)}{JsonTitulos}";
            var json = File.ReadAllText(exePath);
            var listaTitulos = JsonConvert.DeserializeObject<List<Titulo>>(json);

            mockRepository.Setup(mock => mock.GetTitulos()).Returns(listaTitulos);
            TituloRepository = mockRepository.Object;                 
        }
    }
}
