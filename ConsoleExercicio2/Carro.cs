using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExercicio2
{
    public class Carro
    {
        public Carro(string nome, string marca, int anoFabricacao, DateTime dataEntrada)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Marca = marca;
            AnoFabricacao = anoFabricacao;
            DataEntrada = dataEntrada;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Marca { get; private set; }
        public int AnoFabricacao { get; private set; }
        public DateTime DataEntrada { get; private set; }

        public double CalcularQuantidadeDiasNaAgencia()
        {
            var qtdeDias = DateTime.Now - DataEntrada;
            return qtdeDias.Days;
        }
    }
}
