using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models
{
    public class ConsultarFaturamentoRealizadoMetaModel : IBaseModel
    {
        public  List<FaturamentoRealizadoMetaResponseDTO>? FaturamentoRealizadoMetaList { get; set; }
        public EnumAno Ano { get; set; }
        public int Meta { get; set; }
    }
}
