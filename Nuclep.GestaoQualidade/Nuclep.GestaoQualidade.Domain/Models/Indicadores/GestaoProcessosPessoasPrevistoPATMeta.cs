using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class GestaoProcessosPessoasPrevistoPATMeta : IEntidade
    {
        public string? Ano { get; set; }
        public string? Triemeste { get; set; }
        public int Meta { get; set; }

    }
}
