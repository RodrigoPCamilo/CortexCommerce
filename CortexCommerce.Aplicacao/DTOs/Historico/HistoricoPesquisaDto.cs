using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortexCommerce.Aplicacao.DTOs.Historico
{
    public class HistoricoPesquisaDto
    {
        public string Pergunta { get; set; }
        public string RespostaGerada { get; set; }
        public DateTime Data { get; set; }
    }
}