using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.Dominio.Entidades
{
    public class HistoricoPesquisa
    {
       public int Id { get; private set; }

        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        public string Pergunta { get; private set; }
        public string RespostaGerada { get; private set; }

        public DateTime Data { get; private set; }

        protected HistoricoPesquisa() { }

        public HistoricoPesquisa(int usuarioId, string pergunta, string respostaGerada, DateTime data)
        {
            if (string.IsNullOrWhiteSpace(pergunta))
                throw new ArgumentException("Pergunta obrigatória.");

            UsuarioId = usuarioId;
            Pergunta = pergunta;
            RespostaGerada = respostaGerada;
            Data = DateTime.UtcNow;
        } 
    }
}