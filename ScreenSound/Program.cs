using System.ComponentModel.Design;
using System.Runtime;

namespace ScreenSound
{

    internal class Program
    {
        static List<String> opcoesMenu = new List<String>() { "cadastrar uma banda", "listar todas as bandas", "avaliar uma banda", "ver média de uma banda" };
        static List<String> bandasCadastradas = new List<string>() { "Ramones", "Black Sabatah" };
        static Dictionary<string, List<int>> bandasENotas = new Dictionary<string, List<int>>() { {"Ramones", new List<int>()}, { "Black Sabatah", new List<int>() } };
        static void Main(string[] args)
        {
            string opcaoSelecionada = "";
            do
            {
                Titulo();
                Menu(ref opcaoSelecionada);
                ChamaMenuEspecifico(ref opcaoSelecionada);
            }
            while (int.Parse(opcaoSelecionada) != 0);
        }

        private static void Titulo()
        {
            Console.Clear();
            Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
        }

        private static void Menu(ref string opcaoSeleciona)
        {
            Console.WriteLine("\nBem-vindo ao ScreenSound!\n");
            for (int i = 0; i < opcoesMenu.Count; i++)
            {
                Console.WriteLine($"Selecione {i + 1} para {opcoesMenu[i]}.");
            }
            Console.WriteLine($"Selecione 0 para sair.");
            Console.Write("Opção selecionada: ");
            opcaoSeleciona = Console.ReadLine()!;
        }

        private static void ChamaMenuEspecifico(ref string opcaoSeleciona) 
        {
            int x = 0;
            if (!int.TryParse(opcaoSeleciona, out x))
            {
                Console.WriteLine("ERRO: Selecione um valor numérico.");
                opcaoSeleciona = "1";
                Thread.Sleep(2000);
                return;
            }

            switch (int.Parse(opcaoSeleciona))
            {
                case 0:
                    OpcaoSaida();
                    break;
                case 1:
                    OpcaoCadastro();
                    break;
                case 2:
                    OpcaoListarBandas();
                    break;
                case 3:
                    OpcaoAvaliarBandas();
                    break;
                case 4:
                    OpcaoMediaUmaBanda();
                    break;
                default:
                    Console.WriteLine("ERRO: Opção inválida.");
                    Thread.Sleep(2000);
                    break;

            }                
        }

        private static void OpcaoSaida() 
        {
            Console.WriteLine("\nTchauuuuuu :D");
        }
        private static void OpcaoCadastro() 
        {
            PrintTituloMenuEspecifico("CADASTRAR BANDAS");
            Console.Write("Escreva a banda a ser cadastrada: ");
            string nomeBanda = Console.ReadLine()!;
            bandasCadastradas.Add(nomeBanda);
            bandasENotas.Add(nomeBanda, new List<int>());
            Console.WriteLine($"Banda adicionada: {nomeBanda}");
            Thread.Sleep(2000);
        }
        private static void OpcaoListarBandas() 
        {
            PrintTituloMenuEspecifico("LISTAR TODAS AS BANDAS");
            Console.WriteLine("Bandas cadastradas:\n");
            foreach (string banda in bandasCadastradas)
            {
                Console.WriteLine($"{bandasCadastradas.IndexOf(banda)+1}- {banda};");
            }
            Thread.Sleep(3000);
        }
        private static void OpcaoAvaliarBandas()
        {
            PrintTituloMenuEspecifico("AVALIAR UMA BANDA");
            Console.Write("Escreva o nome da banda a ser avaliada: ");
            string banda = Console.ReadLine()!;
            if (bandasENotas.ContainsKey(banda))
            {
                int nota;
                Console.WriteLine("Digite, uma por vez, as notas a serem adicionadas. Se quiser parar, digite -1.");
                do
                {
                    nota = int.Parse(Console.ReadLine()!);
                    if (nota != -1) bandasENotas[banda].Add(nota);
                }
                while (nota != -1);
            }
            else 
            {
                Console.WriteLine("Banda não encontrada.");
                Thread.Sleep(2000);
            }
        }
        private static void OpcaoMediaUmaBanda() 
        {
            PrintTituloMenuEspecifico("MÉDIA DE UMA BANDA");
            Console.Write("Escreva o nome da banda a ser consultada: ");
            string banda = Console.ReadLine()!;
            if (bandasENotas.ContainsKey(banda) && bandasENotas[banda].Count > 0)
            {
                decimal mediaNotas = 0;
                decimal somaDasNotas = bandasENotas[banda].Sum();
                decimal qtdNotas = bandasENotas[banda].Count();
                mediaNotas = somaDasNotas / qtdNotas;
                Console.WriteLine($"Média de {banda}: {mediaNotas}");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Banda não encontrada ou sem notas registradas.");
                Thread.Sleep(2000);
            }
        }

        private static void PrintTituloMenuEspecifico(string nomeMenu)
        {
            Console.Clear();
            int quantidadeCaracteres = nomeMenu.Length;
            string astericos = string.Empty.PadLeft(quantidadeCaracteres, '*');
            Console.WriteLine(astericos);
            Console.WriteLine(nomeMenu);
            Console.WriteLine(astericos+"\n");
        }

    }
}
