﻿using XadrezJogo;
using XadrezJogo.Tabuleiro;
using XadrezJogo.Xadrez;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();


            while(!partida.terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.imprimirPartida(partida);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeOrigem(origem);

                    Console.Clear();
                    bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                    Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);


                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDeDestino(origem, destino);

                    partida.realizaJogada(origem, destino);
                }

                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.Clear();
            Tela.imprimirPartida(partida);
        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}