using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MinutoSeguros.Utils
{
    // Como é possível notar, apliquei o padrão Builder nessa classe.
    public class PrepararConteudoArtigoParaAnalise
    {
        public string TextoPreparado { get; private set; }

        public PrepararConteudoArtigoParaAnalise(string texto)
        {
            this.TextoPreparado = texto;
        }

        public PrepararConteudoArtigoParaAnalise RetirarCaracteresEspeciais()
        {
            this.TextoPreparado = Regex.Replace(this.TextoPreparado, "[;\\/:*?\"<>|&']+", string.Empty);
            return this;
        }

        public PrepararConteudoArtigoParaAnalise RetirarPreposicoes()
        {
            //baseado em http://pt.wikipedia.org/wiki/Lista_de_contra%C3%A7%C3%B5es_e_combina%C3%A7%C3%B5es_na_l%C3%ADngua_portuguesa#Preposi.C3.A7.C3.A3o_.22a.22
            var preposicoes = new string[] { "aos", "às", "ao", "à", "aquele", "aqueles", "aquela", "aquelas", "àquilo", "aquilo", "aonde", "do", "dos", "da", "das",
                                             "deste", "destes", "desta", "destas", "dum", "duns", "duma", "dumas", "dele", "deles", "dela", "delas", "desse", "desses", 
                                             "dessa", "dessas", "daquele", "daqueles", "daquela", "daquelas", "disso", "disto", "daquilo", "daqui", "dai", "daí", "dali", 
                                             "dalí", "dacolá", "donde", "doutro", "doutros", "doutrem", "no", "nos", "na", "nas", "num", "nuns", "numa", "numas", "nele", 
                                             "neles", "nela", "nelas", "nesse", "nesses", "nessa", "nessas", "neste", "nestas", "naquele", "naqueles", "naquela", "naquelas",
                                             "nisto", "nisso", "naquilo", "noutro", "noutros", "noutra", "noutras", "noutrem", "pro", "pros", "pra", "pras", "pelo", "pelos", 
                                             "pela", "pelas", "dentre", "de", "em", "para", "per", "por", "que", "e", "com"};

            foreach (var preposicao in preposicoes)
            {
                this.TextoPreparado = this.TextoPreparado.ToLower().Replace(" " + preposicao + " ", " ");
            }

            return this;
        }

        public PrepararConteudoArtigoParaAnalise RetirarArtigos()
        {
            var artigos = new string[] { "um", "uns", "uma", "umas", "o", "os", "a", "as" };

            foreach (var artigo in artigos)
            {
                this.TextoPreparado = this.TextoPreparado.ToLower().Replace(" " + artigo + " ", " ");
            }

            return this;
        }

        public PrepararConteudoArtigoParaAnalise RetirarMarcacoesHTML()
        {
            this.TextoPreparado = Regex.Replace(this.TextoPreparado, "<.*?>", string.Empty);
            return this;
        }
    }
}
