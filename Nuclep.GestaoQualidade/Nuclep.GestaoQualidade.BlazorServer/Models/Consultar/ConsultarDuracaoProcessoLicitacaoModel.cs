using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarDuracaoProcessoLicitacaoModel : IBaseModel
    {
        public List<DuracaoProcessoLicitacaoResponseDTO>? DuracaoProcessoLicitacaoList { get; set; }

        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? DiasCorridos { get; set; }
        public int Meta { get; set; }
    }
}
