using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinutoSeguros.Interface
{
    //  Interface genérica que define os meios de escrita/leitura que podem ser aplicados em nosso repositório.
    //  No momento, apenas a funcionarilidade de listagem será necessária.
    public interface IRepository<T>
    {
        List<T> Listar();
    }
}
