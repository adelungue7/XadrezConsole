using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezJogo.Tabuleiro;

namespace XadrezJogo.Xadrez
{
    internal class Rei : Peca
    {
        public Rei(TabuleiroJogo tab, Cor cor) : base(tab, cor)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
