using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_de_adivinhação_exceção
{
    internal class Program
    {
        static string error(string maior)
        {
            Console.WriteLine("O número que pensei é MAIOR que o suposto por você");
            maior = Convert.ToString(Console.ReadLine());
            return maior;
        }
        static void Main(string[] args)
        {
            string maior="p";
            var gerador = new Random();// variável designada a gerar valores aleatórios 
            string resposta;// essa variável sera responsável por guardar a última responda do usuário em relaçao ao reinicio do jogo
            int suposicao = 0;// uma variável responsavel por guardar a suposição do usuário

            do
            {
                int aleatorio = gerador.Next(1, 100); // nesta linha a máquina gerará um número aleatório entre 1 e 100, para iniciarmos o jogo 
                Console.Clear(); // serve para limpar a tela do usuario
                Console.WriteLine("Olá jogador! Eu pensei em um número aleatório de 1 a 100 e quero que você adivinhe.");// uma simples apresentação ao jogador/a
                Console.WriteLine("Caso não queira continuar tentando digite STOP a qualquer momento");

                //---- Inicio do laço de repetição destinado a tentativa do usuario ------------

                do
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write("Digite o número que estou pensando: ");
                        resposta = Console.ReadLine().ToUpper();

                        // Esse if serve para verificar se o usuario deseja continuar tentando acertar o número, saindo do laco de repeticao se digitado Stop
                        if (resposta == "STOP")
                        {
                            Console.Clear();
                            Console.WriteLine($"Que pena que você não conseguiu acertar, o número era {aleatorio}");
                            break;
                        }
                        else
                        {
                            suposicao = Convert.ToInt32(resposta);
                        }
                        //------------------------------------

                        // o código entrará nesse específica sequencia caso o jogador acerte a condição mostrada
                        if (suposicao == aleatorio)
                        {
                            Console.Clear();
                            Console.WriteLine($"Parabéns!! Você acertou o número que eu estava pensando que era o {aleatorio}");
                            break;
                        }
                        else // o código entrará nessa sequencia caso o jogador não acerte a condição anteriormente mostrada
                        {

                            Console.WriteLine("Você errou!!");
                            if (aleatorio > suposicao) // esses próximos "ifs" servem para dar dicas e ajudar o jogador a chegar na correta resposta
                            {
                                error(maior);
                                continue;
                            }

                            if (aleatorio < suposicao)
                            {
                                Console.WriteLine("O número que pensei é MENOR que o suposto por você");
                                continue;
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Voce digitou um caracter, digite um número");
                    }
                    }  while (suposicao != aleatorio);

                // ---- Final do laço destinado a tentativa do usuario ----------


                Console.WriteLine("Deseja jogar novamente ? S / N");
                resposta = Console.ReadLine().ToUpper();

            } while (resposta == "S");// esse do-while serve para reiniciar o jogo caso o jogador deseje
        }
    }
}

        
    

