using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class TaxaConformidadeDocumentosQualidade : IEntidade
    {

        public EnumAno Ano1 { get; set; }
        public EnumAno Ano2 { get; set; }
        public long? TotalDocumentos { get; set; }
        public long? TotalDentroPrazo { get; set; }
        public int Meta { get; set; }


    }
}
