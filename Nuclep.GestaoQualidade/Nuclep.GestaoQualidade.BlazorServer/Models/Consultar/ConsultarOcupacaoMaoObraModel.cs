using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarOcupacaoMaoObraModel : IBaseModel
    {
        public List<OcupacaoMaoObraResponseDTO>? OcupacaoMaoObraList { get; set; }

        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? TempoEfetivoFabril { get; set; }
        public long? TempoDisponivelFabril { get; set; }
        public int Meta { get; set; }
    }
}
