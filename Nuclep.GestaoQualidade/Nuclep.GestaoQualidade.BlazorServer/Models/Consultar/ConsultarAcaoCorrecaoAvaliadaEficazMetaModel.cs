using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarAcaoCorrecaoAvaliadaEficazMetaModel : IBaseModel
    {
        public List<AcaoCorrecaoAvaliadaEficazMetaResponseDTO>? AcaoCorrecaoAvaliadaEficazMetaList { get; set; }

        //public EnumTrimestre Trimestre { get; set; }
        public EnumAno Ano { get; set; }
        public int Meta { get; set; }
    }
}
