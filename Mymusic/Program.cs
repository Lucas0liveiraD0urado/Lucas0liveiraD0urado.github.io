using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeiroProjeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string boasVindas = "Seja bem vindo ao MyMusic";
            //List<string> listaBandas = new List<string> { "Slipknot".ToUpper(), "Metallica".ToUpper(), "Avenged Sevenfold".ToUpper() };
            Dictionary<string, List<int>> BandasAdicionadas = new Dictionary<string, List<int>>();
            void MensagemBoasVindas()
            {
                Console.WriteLine(@"            
███╗░░░███╗██╗░░░██╗███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░
████╗░████║╚██╗░██╔╝████╗░████║██║░░░██║██╔════╝██║██╔══██╗
██╔████╔██║░╚████╔╝░██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝
██║╚██╔╝██║░░╚██╔╝░░██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗
██║░╚═╝░██║░░░██║░░░██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝
╚═╝░░░░░╚═╝░░░╚═╝░░░╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░
");
                Console.WriteLine(boasVindas);
            }
            void ExibeOpcao()
            {
                Console.Clear();
                MensagemBoasVindas();
                Console.WriteLine("Oque deseja?\n1 - Registrar Banda;\n2 - Mostrar Banda;\n3 - Avaliar Banda;\n4 - Exibir a média da Banda;\n5 - Sair do MyMusic.");
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Banda Registrar");
                        RegistrarBanda();
                        break;
                    case 2:
                        Console.WriteLine("Mostrar Bandas");
                        MostrarBandas();
                        break;
                    case 3:
                        Console.WriteLine("Avaliar Banda");
                        AvaliarBanda();
                        break;
                    case 4:
                        Console.WriteLine("Exibir Média");
                        ExibeMedia();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Saindo da aplicação");
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("Opção inválida...");
                        Thread.Sleep(1000);
                        ExibeOpcao();
                        break;
                }
            }
            void RegistrarBanda()
            {
                Console.Clear();
                ExibirTitulo("Registrar Bandas");
                Console.Write("Digite o nome da banda que deseja registrar: ");
                string nomeDaBanda = Console.ReadLine().ToUpper();
                BandasAdicionadas.Add(nomeDaBanda, new List<int>());
                Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
                Thread.Sleep(1000);
                Console.Clear();
                ExibeOpcao();

            }
            void MostrarBandas()
            {
                Console.Clear();
                ExibirTitulo("Mostrando Bandas na Lista");
                foreach (string bandas in BandasAdicionadas.Keys)
                {
                    Console.WriteLine($"Banda: {bandas}");
                }
                Thread.Sleep(1000);
                Console.WriteLine("\nAperte quelquer tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibeOpcao();

            }

            void ExibirTitulo(string titulo)
            {
                int quantidadeDeLetras = titulo.Length;
                string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '#');
                Console.WriteLine(asteriscos);
                Console.WriteLine(titulo);
                Console.WriteLine($"{asteriscos}\n");
            }

            void AvaliarBanda()
            {
                Console.Clear();
                ExibirTitulo("Avaliar Banda");
                Console.WriteLine("Bandas disponiveis");
                foreach (string bandas in BandasAdicionadas.Keys)
                {
                    Console.WriteLine($"Banda - {bandas}");
                }
                Console.Write("Digite o nome da banda que deseja avaliar: ");
                string nomeDaBanda = Console.ReadLine().ToUpper();
                if (BandasAdicionadas.ContainsKey(nomeDaBanda))
                {
                    Console.Write($"Qual nota a banda {nomeDaBanda} merece? (de 1 até 10): ");
                    int nota = int.Parse(Console.ReadLine());
                    if (nota <= 10 && nota >= 1)
                    {

                        BandasAdicionadas[nomeDaBanda].Add(nota);
                        Console.WriteLine($"\nA nota: {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
                        Thread.Sleep(2000);
                        Console.Clear();
                        ExibeOpcao();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Essa nota é inválida...\nVoltando ao menu principal");
                        Thread.Sleep(2000);
                        ExibeOpcao();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"A banda: {nomeDaBanda} Não foi encontrada!\nVoltando ao menu principal.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    ExibeOpcao();
                }
            }
            void ExibeMedia()
            {
                Console.Clear();
                ExibirTitulo("Exibir Média da Banda");
                Console.WriteLine("Qual banda deseja saber a média de notas?");
                string aMediabanda = Console.ReadLine().ToUpper();
                if (BandasAdicionadas.ContainsKey(aMediabanda))
                {
                    Console.Clear();
                    double media = BandasAdicionadas[aMediabanda].Average();
                    Console.WriteLine($"A média da banda {aMediabanda} é {media}");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Thread.Sleep(500);
                    Console.Clear();
                    ExibeOpcao();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"A banda: {aMediabanda} não se encontra na lista...\nVoltando ao menu principal");
                    Thread.Sleep(2000);
                    ExibeOpcao();

                }
            }
            ExibeOpcao();


        }
    }
}
