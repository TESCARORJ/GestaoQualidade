using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarCumprimentoEtapasPACDentroPrazoMetaModel : IBaseModel
    {
        public List<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>? CumprimentoEtapasPACDentroPrazoMetaList { get; set; }

        //public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public int Meta { get; set; }
    }
}
