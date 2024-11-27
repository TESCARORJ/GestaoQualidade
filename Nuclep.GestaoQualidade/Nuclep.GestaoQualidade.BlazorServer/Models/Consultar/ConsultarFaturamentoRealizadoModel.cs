using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarFaturamentoRealizadoModel : IBaseModel
    {
        public List<FaturamentoRealizadoResponseDTO>? FaturamentoRealizadoList { get; set; }

        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? SomatorioFaturamentoRealizadoTrimestre { get; set; }
        public long? PrevistoJaneiroAnoCorrente { get; set; }
        public int Meta { get; set; }
    }
}
