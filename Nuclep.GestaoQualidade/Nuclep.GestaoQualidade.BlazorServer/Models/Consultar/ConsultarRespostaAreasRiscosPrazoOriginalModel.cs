using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarRespostaAreasRiscosPrazoOriginalModel : IBaseModel
    {
        public List<RespostaAreasRiscosPrazoOriginalResponseDTO>? RespostaAreasRiscosPrazoOriginalList { get; set; }

        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? Realizado { get; set; }
        public int Meta { get; set; }
    }
}
