using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models
{
    public class ConsultarTaxaConformidadeDocumentosQualidadeMetaModel : IBaseModel
    {
        public  List<TaxaConformidadeDocumentosQualidadeMetaResponseDTO>? TaxaConformidadeDocumentosQualidadeMetaList { get; set; }
        public EnumAno Ano1 { get; set; }
        public EnumAno Ano2 { get; set; }
        public int Meta { get; set; }
    }
}
