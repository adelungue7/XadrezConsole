using XadrezJogo;
using XadrezJogo.Tabuleiro;
using XadrezJogo.Xadrez;

internal class Program
{
    private static void Main(string[] args)
    {
        TabuleiroJogo tab = new TabuleiroJogo(8, 8);

        tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 5));
        tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(5, 2));
        tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(3, 6));

        Tela.imprimirTabuleiro(tab);

        Console.ReadLine();
    }
}