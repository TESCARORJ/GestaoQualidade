using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarAderenciaProgramacaoMensalModel : IBaseModel
    {
        public List<AderenciaProgramacaoMensalResponseDTO>? AderenciaProgramacaoMensalList { get; set; }

        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? TotalAtividadesProgramadas { get; set; }
        public long? AtividadesRealizadas { get; set; }
        public long? AtividadesCanceladas { get; set; }
        public int Meta { get; set; }
    }
}
