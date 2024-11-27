using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class AutoavaliacaoGerencialSGQMeta : IEntidade
    {
        public EnumAno Ano { get; set; }
        public int Meta { get; set; }

    }
}
