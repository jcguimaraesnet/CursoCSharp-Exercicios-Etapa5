using System;

namespace ConsoleExercicio1
{
    public class ItemPedido
    {
        public ItemPedido(string descricao, int quantidade, double preco)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Quantidade = quantidade;
            Preco = preco;
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public int Quantidade { get; private set; }
        public double Preco { get; private set; }

        public double CalcularTotal() => Quantidade * Preco;
    }
}
