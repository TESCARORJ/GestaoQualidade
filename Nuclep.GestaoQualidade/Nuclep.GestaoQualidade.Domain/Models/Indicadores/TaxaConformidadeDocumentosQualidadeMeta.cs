using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class TaxaConformidadeDocumentosQualidadeMeta : IEntidade
    {
        public string? Nome { get; set; }
        public int Meta { get; set; }

    }
}
