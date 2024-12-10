using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarServiceLevelAgreementMetaModel : IBaseModel
    {
        public List<ServiceLevelAgreementMetaResponseDTO>? ServiceLevelAgreementMetaList { get; set; }

        //public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public int Meta { get; set; }
    }
}
