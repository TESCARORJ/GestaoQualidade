using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarTaxaConformidadeDocumentosQualidadeModel : IBaseModel
    {
        public List<TaxaConformidadeDocumentosQualidadeResponseDTO>? TaxaConformidadeDocumentosQualidadeList { get; set; }

        public EnumAno Ano1 { get; set; }
        public EnumAno Ano2 { get; set; }
        public long? TotalDocumentos { get; set; }
        public long? TotalDentroPrazo { get; set; }
        public int Meta { get; set; }
    }
}
