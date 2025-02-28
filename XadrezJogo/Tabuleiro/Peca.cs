using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadrezJogo.Tabuleiro
{
    internal class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public TabuleiroJogo tab { get; set; }

        public Peca(Posicao posicao, Cor cor, TabuleiroJogo tab)
        {
            this.posicao = posicao;
            this.cor = cor;
            this.tab = tab;
            qteMovimentos = 0;
        }
    }
}
