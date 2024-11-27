using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class TaxaConformidadeDocumentosQualidade : IEntidade
    {

        public string? Ciclo { get; set; }
        public decimal Realizado { get; set; }
        public int Meta { get; set; }


    }
}
