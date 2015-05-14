using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinutoSeguro.DataTransferObject
{
    public class AnaliseArtigo
    {
        public Artigo Artigo { get; set; }
        public int TotalPalavras { get; set; }
        public List<Palavra> Palavras { get; set; }
    }
}
