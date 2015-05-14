using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MinutoSeguro.DataTransferObject
{
    // Esta classe representa um entidade que faz parte do domínio de nossa aplicação.
    public class Artigo
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
      
        public static Artigo Mapear(XmlNode node)
        {
            var artigo = new Artigo();
            artigo.Titulo = node.SelectSingleNode("title").InnerText;
            artigo.Conteudo = node.ChildNodes[8].InnerText;
            return artigo;
        }
    }
}
