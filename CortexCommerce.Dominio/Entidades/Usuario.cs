using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Enums;

namespace CortexCommerce.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }

        public string CategoriaFavorita { get; private set; }
        public decimal OrcamentoMedio { get; private set; }
        public LojaPreferida LojaPreferida { get; private set; }

        public DateTime DataCriacao { get; private set; }
        public ICollection<HistoricoPesquisa> HistoricoPesquisa { get; set; } = new List<HistoricoPesquisa>();

        protected Usuario()
        {

        }
        public Usuario(string nome, string email,string senha, string categoriaFavorita, decimal orcamentoMedio, LojaPreferida lojaPreferida)
        {
            Validar(nome, email, orcamentoMedio);
            Nome = nome;
            Email = email;
            SenhaHash = BCrypt.Net.BCrypt.HashPassword (senha);
            CategoriaFavorita = categoriaFavorita;
            OrcamentoMedio = orcamentoMedio;
            LojaPreferida = lojaPreferida;
            DataCriacao = DateTime.UtcNow;
        }
        public bool ValidarSenha(string senha)
        {
            return BCrypt.Net.BCrypt.Verify(senha, SenhaHash);
        }
        public void AtualizarPreferencias(
             string categoriaFavorita,
             decimal orcamentoMedio,
             LojaPreferida lojaPreferida)
        {
            if (orcamentoMedio <= 0)
                throw new ArgumentException("Orçamento inválido.");

            CategoriaFavorita = categoriaFavorita;
            OrcamentoMedio = orcamentoMedio;
            LojaPreferida = lojaPreferida;
        }

          public void AtualizarDados(string nome, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome inválido");

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email inválido");

        Nome = nome;
        Email = email;
    }

        private void Validar(string nome, string email, decimal orcamentoMedio)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome obrigatório.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Email inválido.");

            if (orcamentoMedio <= 0)
                throw new ArgumentException("Orçamento inválido.");
        }
    }
}