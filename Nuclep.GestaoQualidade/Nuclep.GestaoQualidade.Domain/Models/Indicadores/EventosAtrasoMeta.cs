using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class EventosAtrasoMeta : IEntidade
    {
        public string? Ano { get; set; }
        public int Meta { get; set; }

    }
}
