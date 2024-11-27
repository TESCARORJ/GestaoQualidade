using Nuclep.GestaoQualidade.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class AcaoCorrecaoAvaliadaEficazRequestDTO
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public EnumAno Ano { get; set; }
        public long? TotalAbertura { get; set; }
        public long? TotalFechamento { get; set; }
        public long? TotalTratamentoEficaz { get; set; }
        public int Meta { get; set; }
    }
}
