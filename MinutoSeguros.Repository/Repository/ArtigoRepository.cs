using MinutoSeguro.DataTransferObject;
using MinutoSeguros.Interface;
using MinutoSeguros.Utils.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinutoSeguros.Repository
{
    // Essa classe implementa os comportamentos definidos pela interface IArtigoRepository.
    public class ArtigoRepository:IArtigoRepository
    {
        protected string url = string.Empty;

        // Injeção de dependência: obriga o repositório a ser iniciado com uma url.
        public ArtigoRepository(string u)
        {
            if (string.IsNullOrEmpty(u))
                throw new NotImplementedException("Informe um endereço válido para o Repositório");

            this.url = u;
        }

        public List<Artigo> Listar()
        {
            var artigosSerializados = AcessaWeb.RealizarRequisicaoEmWebServiceXML(this.url);
            var artigos = new List<Artigo>();

            foreach (System.Xml.XmlNode noArtigo in artigosSerializados.SelectNodes("rss/channel/item"))
            {
                var artigo = Artigo.Mapear(noArtigo);
                artigos.Add(artigo);
            }

            return artigos;
        }
    }
}
