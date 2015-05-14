using MinutoSeguro.DataTransferObject;
using MinutoSeguros.Interface;
using MinutoSeguros.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinutoSeguros.Utils;

namespace MinutoSeguros.Business
{
    // Classe responsável por aplicar toda a regra de negócio requisitada na entidade Artigo
    public class ArtigoBusiness
    {
        protected IArtigoRepository artigoRepository = null;

        public ArtigoBusiness(string url)
        {
            this.artigoRepository = new ArtigoRepository(url);
        }

        public IEnumerable<AnaliseArtigo> AnalisarDezPrincipaisPalavrasNosArtigos()
        {
            var artigos = this.artigoRepository.Listar();

            foreach (var artigo in artigos)
            {
                const int LIMITE_RANKING = 10;
                var analiseArtigo = new AnaliseArtigo { Artigo = artigo };

                var preparador = new PrepararConteudoArtigoParaAnalise(artigo.Conteudo).                                                                        
                                                                        RetirarPreposicoes().
                                                                        RetirarArtigos().
                                                                        RetirarMarcacoesHTML().
                                                                        RetirarCaracteresEspeciais();

                var palavras = preparador.TextoPreparado.Split(' ');
                analiseArtigo.TotalPalavras = palavras.Count();

                //  Realiza a contagem das palavras. Solução baseada em resposta concedida neste 
                //  tópico: http://stackoverflow.com/questions/454601/how-to-count-duplicates-in-list-with-linq

                var rankingdePalavras = (from pal in palavras
                                         group pal by pal into p
                                         let total = p.Count()
                                         orderby total descending
                                         select new { Palavra = p.Key, TotalAparecimento = total }).ToList().Take(LIMITE_RANKING);



                analiseArtigo.Palavras = new List<Palavra>();

                foreach (var ranking in rankingdePalavras)
                {
                    var palavra = new Palavra();
                    palavra.Descricao = ranking.Palavra;
                    palavra.QuantidadeDeVezesQueAparece = ranking.TotalAparecimento;
                    analiseArtigo.Palavras.Add(palavra);
                }

                yield return analiseArtigo;
            }
        }
    }
}
