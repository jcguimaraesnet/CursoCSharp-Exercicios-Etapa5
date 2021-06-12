using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleExercicio1
{
    class Program
    {
        private const string pressioneQualquerTecla = "Pressione qualquer tecla para exibir o menu principal ...";
        private static List<ItemPedido> listaItensPedido = new List<ItemPedido>();

        static void Main(string[] args)
        {
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Cadastro de Itens de Pedido");
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Adicionar Item de Pedido a NF");
                Console.WriteLine("2 - Calcular e Exibir Valor Total da NF");
                Console.WriteLine("3 - Sair");

                opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1": AdicionarItemPedido(); break;
                    case "2": ExibirValorTotal(); break;
                    case "3": Console.Write("Saindo do programa... "); break;
                    default: throw new NotImplementedException("Opção inválida");
                };

            } while (opcao != "3");
        }

        static void AdicionarItemPedido()
        {
            Console.WriteLine("Informe a descrição do produto:");
            var descricao = Console.ReadLine();

            Console.WriteLine("Informe a quantidade");
            if (!int.TryParse(Console.ReadLine(), out var quantidade))
            {
                Console.WriteLine($"Valor inválido! Dados descartados! {pressioneQualquerTecla}");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Informe o preço (unitário) do produto");
            if (!double.TryParse(Console.ReadLine(), out var preco))
            {
                Console.WriteLine($"Valor inválido! Dados descartados! {pressioneQualquerTecla}");
                Console.ReadKey();
                return;
            }

            listaItensPedido.Add(new ItemPedido(descricao, quantidade, preco));
            Console.WriteLine($"Item de pedido adicionado com sucesso! {pressioneQualquerTecla}");
        }

        static void ExibirValorTotal()
        {
            Console.WriteLine($" Valor Total dos itens de Pedido: {listaItensPedido.Sum(item => item.CalcularTotal())}");
            Console.ReadKey();
        }
    }
}
