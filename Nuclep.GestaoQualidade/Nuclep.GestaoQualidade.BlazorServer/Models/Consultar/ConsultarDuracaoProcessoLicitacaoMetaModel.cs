using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models
{
    public class ConsultarDuracaoProcessoLicitacaoMetaModel : IBaseModel
    {
        public  List<DuracaoProcessoLicitacaoMetaResponseDTO>? DuracaoProcessoLicitacaoMetaList { get; set; }
        public EnumAno Ano { get; set; }
        public int Meta { get; set; }
    }
}
