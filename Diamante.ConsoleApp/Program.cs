using System;

namespace Diamante.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string comando = null;

            do
            {
                Console.Write("Digite um número impar maior do que 1 para a quantidade de colunas do diamante: ");
                int n = int.Parse(Console.ReadLine());

                while (n % 2 == 0 || n == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Entrada inválida! ");
                    Console.ResetColor();
                    Console.Write("Digite um número impar maior do que 1 para a quantidade de colunas do diamante: ");
                    n = int.Parse(Console.ReadLine());
                }

                Console.WriteLine();

                char[] x = new char[n];
                int meioNumero = (n / 2) + 1;
                int meioChar = n / 2;
                int posAcima = meioChar;
                int posAbaixo = meioChar;

                // passando valor em branco para todas as posições do array
                for (int i = 0; i < n; i++)
                {
                    x[i] = ' ';
                }


                // definindo que a posição do meio é igual a X
                x[meioChar] = 'X';


                // inicio da construção do diamente, do inicio até o meio
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


                // passando valor X para todas as posições do array
                for (int i = 0; i < n; i++)
                {
                    x[i] = 'X';
                }

                posAcima = 0;
                posAbaixo = x.Length - 1;
                x[posAcima] = ' ';
                x[posAbaixo] = ' ';


                // inicio da construção do diamente, do meio até o final
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


                // controle de continuidade do programa
                Console.Write("Digite S para SAIR ou C para CONTINUAR: ");
                comando = Console.ReadLine();

                while (comando != "S" && comando != "C")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Entrada inválida! ");
                    Console.ResetColor();
                    Console.Write("Digite S para SAIR ou C para CONTINUAR: ");
                    comando = Console.ReadLine();
                }

                Console.WriteLine();

            } while (comando == "C");
        }
    }
}

