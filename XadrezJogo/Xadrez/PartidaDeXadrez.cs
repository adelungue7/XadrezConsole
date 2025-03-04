using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XadrezJogo.Tabuleiro;

namespace XadrezJogo.Xadrez
{
    internal class PartidaDeXadrez
    {
        public TabuleiroJogo tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            tab = new TabuleiroJogo(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }
        public HashSet<Peca> pecasCapturadas(Cor cor) 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca peca in capturadas)
            {
                if(peca.cor == cor)
                {
                    aux.Add(peca);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in pecas)
            {
                if (peca.cor == cor)
                {
                    aux.Add(peca);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if(!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Preta));
            colocarNovaPeca('f', 6, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b', 3, new Torre(tab, Cor.Branca));
            colocarNovaPeca('a', 5, new Torre(tab, Cor.Branca));
        }
    }
}
