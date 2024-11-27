using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class RespostaAreasPrazoOriginalMeta : IEntidade
    {
        public string? Ano { get; set; }
        public string? Trimestre { get; set; }
        public int Meta { get; set; }

    }
}
