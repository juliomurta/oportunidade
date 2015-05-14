using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace MinutoSeguros.Utils.Web
{
    // Classe utilitária responsável por realizar requisições através da Web
    public class AcessaWeb
    {
        public static XmlDocument RealizarRequisicaoEmWebServiceXML(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    var requisicao = WebRequest.Create(url);
                    var resposta = requisicao.GetResponse();
                    var dadosEmStream = resposta.GetResponseStream();
                    var leitorStream = new StreamReader(dadosEmStream);                    
                    var respostaXML = new XmlDocument();
                    respostaXML.LoadXml(leitorStream.ReadToEnd());
                    return respostaXML;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro durante a requisição : " + ex.Message);
                }
            }

            throw new Exception("URL inválida");
        }
    }
}
