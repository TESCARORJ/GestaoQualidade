using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models
{
    public class CadatrarTaxaConformidadeDocumentosQualidadeMetaModel : IBaseModel
    {
        public EnumAno Ano1 { get; set; }
        public EnumAno Ano2 { get; set; }
        public int Meta { get; set; }
    }
}
