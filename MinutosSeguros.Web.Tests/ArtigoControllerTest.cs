using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinutoSeguros.Business;
using MinutoSeguro.DataTransferObject;

namespace MinutosSeguros.Web.Tests
{
    [TestClass]
    public class ArtigoControllerTest
    {
        [TestMethod]
        public void TestaConsultaDeArtigos()
        {           
            var artigoBusiness = new ArtigoBusiness("http://www.minutoseguros.com.br/blog/feed/");
            var resultado = artigoBusiness.AnalisarDezPrincipaisPalavrasNosArtigos();
            Assert.AreEqual(10, new List<AnaliseArtigo>(resultado).Count);
            Assert.AreEqual(10, new List<AnaliseArtigo>(resultado)[0].Palavras.Count);
        }
    }
}
