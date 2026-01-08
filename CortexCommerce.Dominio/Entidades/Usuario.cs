using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public string CategoriaFavorita { get; private set; }
        public decimal OrcamentoMedio { get; private set; }
        public DateTime DatCriacao { get; private set; }
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

        protected Usuario()
        {

        }
        public Usuario(string nome, string email, string senha, string categoriaFavorita, decimal orcamentoMedio)
        {
            Validar(nome, email, senha, orcamentoMedio);
            Nome = nome;
            Email = email;
            Senha = senha;
            CategoriaFavorita = categoriaFavorita;
            OrcamentoMedio = orcamentoMedio;
            DatCriacao = DateTime.UtcNow;
        }
        private void Validar(string nome, string email, string senha, decimal orcamentoMedio)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Um email válido é obrigatório.");

            if (string.IsNullOrWhiteSpace(senha) || senha.Length < 6)
                throw new ArgumentException("A senha deve ter pelo menos 6 caracteres.");

            if (orcamentoMedio < 0)
                throw new ArgumentException("O orçamento médio não pode ser negativo.");
        }
    }
}