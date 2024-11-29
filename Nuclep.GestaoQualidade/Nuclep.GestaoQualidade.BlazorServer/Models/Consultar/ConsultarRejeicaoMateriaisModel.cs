using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarRejeicaoMateriaisModel : IBaseModel
    {
        public List<RejeicaoMateriaisResponseDTO>? RejeicaoMateriaisList { get; set; }

        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? TotalCTIsRejeitados { get; set; }
        public long? TotalCTIsFinalizados { get; set; }
        public int Meta { get; set; }
    }
}
