using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarAcaoCorrecaoAvaliadaEficazModel : IBaseModel
    {
        public List<AcaoCorrecaoAvaliadaEficazResponseDTO>? AcaoCorrecaoAvaliadaEficazList { get; set; }

        public EnumTrimestre Trimestre { get; set; }
        public EnumAno Ano { get; set; }
        public long? TotalAbertura { get; set; }
        public long? TotalFechamento { get; set; }
        public long? TotalTratamentoEficaz { get; set; }
        public int Meta { get; set; }
    }
}
