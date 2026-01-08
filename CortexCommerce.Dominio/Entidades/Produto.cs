using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Categoria { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public List<ItemPedido> ItemsPedido { get; private set; } = new List<ItemPedido>();

        protected Produto()
        {

        }
        public Produto(string nome, string descricao, string categoria, decimal preco, int estoque)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto é obrigatório.");
            if (preco < 0)
                throw new ArgumentException("O preço do produto não pode ser negativo.");
            if (estoque < 0)
                throw new ArgumentException("O estoque do produto não pode ser negativo.");

            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Preco = preco;
            Estoque = estoque;
        }
        public void BaixarEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");
            if (quantidade > Estoque)
                throw new InvalidOperationException("Estoque insuficiente.");

            Estoque -= quantidade;
        }
    }
}