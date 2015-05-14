using MinutoSeguro.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinutoSeguros.Interface
{
    //  Optei pela criação de uma interface mais específica para o repositório artigo pois,
    //  numa aplicação real, possivelmente o repositório de artigos teria métodos que dissesem 
    //  respeito apenas para essa entidade, tais como ConsultarArtigosPorAutor() ou PesquisarArtigosPorCategoria().
    public interface IArtigoRepository : IRepository<Artigo>
    {

    }
}
