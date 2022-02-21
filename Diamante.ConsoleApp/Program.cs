using System;

namespace Diamante.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comando = null;

            // leitura e controle do dado de entrada
            do
            {   
                int n = PedeEGuardaNumeroEntrada();

                while (n % 2 == 0 || n == 1)
                {
                    MensagemDeErro("Número inválido! Tente novamente. ", ConsoleColor.Red);
                    n = PedeEGuardaNumeroEntrada();
                }

                Console.WriteLine();

                // declaração das variáveis de apoio da parte superior do diamante
                char[] x = new char[n];
                int meioNumero = (n / 2) + 1;
                int meioChar = n / 2;
                int posAcima = meioChar;
                int posAbaixo = meioChar;

                // passando valor em branco para todas as posições do array
                PassaValorEmBrancoArray(n, x);

                // definindo que a posição do meio é igual a X
                x[meioChar] = 'X';

                // inicio da construção do diamente, do inicio até o meio
                ParteSuperiorDiamante(n, x, meioNumero, ref posAcima, ref posAbaixo);

                // passando valor X para todas as posições do array
                PassaValorXArray(n, x);

                // declaração das variáveis de apoio da parte inferior do diamante
                posAcima = 0;
                posAbaixo = x.Length - 1;
                x[posAcima] = ' ';
                x[posAbaixo] = ' ';

                // inicio da construção do diamente, do meio até o final
                ParteInferiorDiamante(n, x, meioNumero, ref posAcima, ref posAbaixo);

                // controle de continuidade do programa
                comando = PedeEGuardaSairOuContinuar();

                while (comando != "S" && comando != "C")
                {
                    MensagemDeErro("Entrada inválida! ", ConsoleColor.Red);
                    comando = PedeEGuardaSairOuContinuar();

                }

                Console.WriteLine();

            } while (comando == "C");
        }

        #region métodos utilizados
        private static void ParteInferiorDiamante(int n, char[] x, int meioNumero, ref int posAcima, ref int posAbaixo)
        {
            for (int i = 0; i < meioNumero; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(x[j]);
                }

                Console.WriteLine();

                if (posAcima < n - 1)
                {
                    posAcima++;
                }

                if (posAbaixo > 0)
                {
                    posAbaixo--;
                }

                x[posAcima] = ' ';
                x[posAbaixo] = ' ';

            }
        }

        private static void PassaValorXArray(int n, char[] x)
        {
            for (int i = 0; i < n; i++)
            {
                x[i] = 'X';
            }
        }

        private static void PassaValorEmBrancoArray(int n, char[] x)
        {
            for (int i = 0; i < n; i++)
            {
                x[i] = ' ';
            }
        }

        private static void ParteSuperiorDiamante(int n, char[] x, int meioNumero, ref int posAcima, ref int posAbaixo)
        {
            for (int i = 0; i < meioNumero; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(x[j]);
                }

                Console.WriteLine();

                if (posAcima < n - 1)
                {
                    posAcima++;
                }

                if (posAbaixo > 0)
                {
                    posAbaixo--;
                }

                x[posAcima] = 'X';
                x[posAbaixo] = 'X';

            }
        }

        private static string PedeEGuardaSairOuContinuar()
        {
            string comando;
            Console.Write("Digite S para SAIR ou C para CONTINUAR: ");
            comando = Console.ReadLine();
            return comando;
        }

        private static void MensagemDeErro(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.Write(mensagem);
            Console.ResetColor();
        }

        private static int PedeEGuardaNumeroEntrada()
        {
            Console.Write("Digite um número impar maior do que 1 para a quantidade de colunas do diamante: ");
            int n = int.Parse(Console.ReadLine());
            return n;
        }

        #endregion

    }
}

