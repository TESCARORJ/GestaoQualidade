using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class DuracaoProcessoLicitacao : IEntidade
    {
        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? DiasCorridos { get; set; }
        public int Meta { get; set; }
    }
}
