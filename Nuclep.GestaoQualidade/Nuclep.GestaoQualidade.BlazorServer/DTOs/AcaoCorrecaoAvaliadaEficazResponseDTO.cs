using Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs
{
    public class AcaoCorrecaoAvaliadaEficazResponseDTO
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
