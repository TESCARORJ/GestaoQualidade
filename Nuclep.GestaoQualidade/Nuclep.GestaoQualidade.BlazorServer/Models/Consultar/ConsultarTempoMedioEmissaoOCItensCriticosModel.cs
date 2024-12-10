using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarTempoMedioEmissaoOCItensCriticosModel : IBaseModel
    {
        public List<TempoMedioEmissaoOCItensCriticosResponseDTO>? TempoMedioEmissaoOCItensCriticosList { get; set; }
        public EnumAno Ano { get; set; }
        public EnumMes Mes { get; set; }
        public long? Realizado { get; set; }
        public int Meta { get; set; }
    }
}
