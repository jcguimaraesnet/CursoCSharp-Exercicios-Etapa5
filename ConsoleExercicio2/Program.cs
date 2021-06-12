using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleExercicio2
{
    class Program
    {
        private const string pressioneQualquerTecla = "Pressione qualquer tecla para exibir o menu principal ...";
        private static List<Carro> listaCarros = new List<Carro>();

        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("*** Gerenciador de Carros *** ");
                Console.WriteLine("1 - Pesquisar Carros:");
                Console.WriteLine("2 - Adicionar Carros:");
                Console.WriteLine("3 - Sair:");
                Console.WriteLine("\nEscolha uma das opções acima: ");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1": PesquisarCarros(); break;
                    case "2": AdicionarCarro(); break;
                    case "3": Console.Write("Saindo do programa... "); break;
                    default: throw new NotImplementedException("Opção inválida");
                };

            } while (opcao != "3");
        }

        static void PesquisarCarros()
        {
            Console.WriteLine("Informe o nome do carro que deseja pesquisar:");
            var termoDePesquisa = Console.ReadLine();
            var carrosEncontrados = listaCarros.Where(carro => carro.Nome.ToLower().Contains(termoDePesquisa.ToLower()))
                                                     .ToList();

            if (carrosEncontrados.Count > 0)
            {
                Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados dos carros encontrados:");
                for (var index = 0; index < carrosEncontrados.Count; index++)
                    Console.WriteLine($"{index} - {carrosEncontrados[index].Nome}");

                if (!ushort.TryParse(Console.ReadLine(), out var indexAExibir) || indexAExibir > carrosEncontrados.Count)
                {
                    Console.WriteLine($"Opção inválida! {pressioneQualquerTecla}");
                    Console.ReadKey();
                }
                else
                {
                    var carro = carrosEncontrados[indexAExibir];

                    Console.WriteLine("Dados do carro");
                    Console.WriteLine($"Nome do carro: {carro.Nome}");
                    Console.WriteLine($"Marca do carro: {carro.Marca}");
                    Console.WriteLine($"Ano do carro: {carro.AnoFabricacao}");
                    Console.WriteLine($"Data de entrada do carro na agência: {carro.DataEntrada:dd/MM/yyyy}");

                    var qtdeDiasNaAgencia = carro.CalcularQuantidadeDiasNaAgencia();
                    Console.WriteLine($"Este carro está a {qtdeDiasNaAgencia} dias disponível para venda na agência.");

                    Console.Write(pressioneQualquerTecla);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"Não foi encontrado nenhum carro! {pressioneQualquerTecla}");
                Console.ReadKey();
            }
        }

        static void AdicionarCarro()
        {
            Console.WriteLine("Informe o nome do carro que deseja adicionar:");
            var nomeCarro = Console.ReadLine();

            Console.WriteLine("Informe a marca do carro que deseja adicionar:");
            var marcaCarro = Console.ReadLine();

            Console.WriteLine("Informe o ano de fabricação do carro:");
            if (!int.TryParse(Console.ReadLine(), out var anoFabricacao))
            {
                Console.WriteLine($"Dado inválido! Dados descartados! {pressioneQualquerTecla}");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Informe a data de entrada do carro na agência (formato DD/MM/YYYY):");
            if (!DateTime.TryParse(Console.ReadLine(), out var dataEntrada))
            {
                Console.WriteLine($"Dado inválido! Dados descartados! {pressioneQualquerTecla}");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Os dados estão corretos?");
            Console.WriteLine($"Nome do carro: {nomeCarro}");
            Console.WriteLine($"Marca do carro: {marcaCarro}");
            Console.WriteLine($"Ano Fabricação do carro: {anoFabricacao}");
            Console.WriteLine($"Data de entrada na agência: {dataEntrada:dd/MM/yyyy}");
            Console.WriteLine("1 - Sim \n2 - Não");

            var opcaoParaAdicionar = Console.ReadLine();

            if (opcaoParaAdicionar == "1")
            {
                listaCarros.Add(new Carro(nomeCarro, marcaCarro, anoFabricacao, dataEntrada));
                Console.WriteLine($"Dados adicionados com sucesso! {pressioneQualquerTecla}");
                Console.ReadKey();
            }
            else if (opcaoParaAdicionar == "2")
            {
                Console.WriteLine($"Dados descartados! {pressioneQualquerTecla}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Opção inválida! {pressioneQualquerTecla}");
                Console.ReadKey();
            }
        }

    }
}
