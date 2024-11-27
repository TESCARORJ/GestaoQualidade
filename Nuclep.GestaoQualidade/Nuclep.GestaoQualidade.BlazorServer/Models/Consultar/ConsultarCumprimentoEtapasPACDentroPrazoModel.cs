using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarCumprimentoEtapasPACDentroPrazoModel : IBaseModel
    {
        public List<CumprimentoEtapasPACDentroPrazoResponseDTO>? CumprimentoEtapasPACDentroPrazoList { get; set; }

        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? PACPrazo { get; set; }
        public long? TotalPACAberto { get; set; }
        public int Meta { get; set; }
    }
}
