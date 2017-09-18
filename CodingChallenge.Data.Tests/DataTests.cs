using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;
using CodingChallenge.Data.Comunes;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVaciaTitulos()
        {
            Assert.AreEqual("<h1>¡Lista vacía de títulos!</h1>",
                Titulo.ImprimirResumen(new List<Titulo>(), Idiomas.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaTitulosEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of securities!</h1>",
                Titulo.ImprimirResumen(new List<Titulo>(), Idiomas.Ingles));
        }

        [TestCase]
        public void TestResumenListaConUnaAccion()
        {
            var acciones = new List<Titulo> { new Titulo { Tipo = TiposTitulo.Accion, Simbolo = "PRUEBA" } };

            Assert.AreEqual("<h1>Resumen de títulos</h1>Detalle de 1 Acción<br/><br/><span>Símbolo Acción: PRUEBA</span><br/><br/>",
                Titulo.ImprimirResumen(acciones, Idiomas.Castellano));
        }

        [TestCase]
        public void TestResumenListaConMasAcciones()
        {
            var acciones = new List<Titulo>
            {
                new Titulo {Tipo = TiposTitulo.Accion, Simbolo = "PRUEBA"},
                new Titulo {Tipo = TiposTitulo.Accion, Simbolo = "PRUEBA_2"}
            };

            Assert.AreEqual("<h1>Resumen de títulos</h1>Detalle de 2 Acciones<br/><br/><span>Símbolo Acción: PRUEBA</span><br/>" +
                            "<span>Símbolo Acción: PRUEBA_2</span><br/><br/>",
                Titulo.ImprimirResumen(acciones, Idiomas.Castellano));
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var titulos = new List<Titulo>
            {
                new Titulo {Tipo = TiposTitulo.Accion, Simbolo = "PRUEBA"},
                new Titulo {Tipo = TiposTitulo.Accion, Simbolo = "PRUEBA_2"},
                new Titulo {Tipo = TiposTitulo.Bono, Simbolo = "BONO_PRUEBA"},
                new Titulo {Tipo = TiposTitulo.Bono, Simbolo = "BONO_PRUEBA_2"}
            };

            Assert.AreEqual("<h1>Resumen de títulos</h1>" +
                            "Detalle de 2 Acciones<br/><br/><span>Símbolo Acción: PRUEBA</span><br/><span>Símbolo Acción: PRUEBA_2</span><br/><br/>" +
                            "Detalle de 2 Bonos<br/><br/><span>Símbolo Bono: BONO_PRUEBA</span><br/><span>Símbolo Bono: BONO_PRUEBA_2</span><br/><br/>",
                Titulo.ImprimirResumen(titulos, Idiomas.Castellano));
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnIngles()
        {
            var titulos = new List<Titulo>
            {
                new Titulo {Tipo = TiposTitulo.Accion, Simbolo = "PRUEBA"},
                new Titulo {Tipo = TiposTitulo.Accion, Simbolo = "PRUEBA_2"},
                new Titulo {Tipo = TiposTitulo.Bono, Simbolo = "BONO_PRUEBA"},
                new Titulo {Tipo = TiposTitulo.Bono, Simbolo = "BONO_PRUEBA_2"}
            };

            Assert.AreEqual("<h1>Securities report</h1>" +
                            "Detail of 2 Stocks<br/><br/><span>Symbol Stock: PRUEBA</span><br/><span>Symbol Stock: PRUEBA_2</span><br/><br/>" +
                            "Detail of 2 Bonds<br/><br/><span>Symbol Bond: BONO_PRUEBA</span><br/><span>Symbol Bond: BONO_PRUEBA_2</span><br/><br/>",
                Titulo.ImprimirResumen(titulos, Idiomas.Ingles));
        }
    }
}
