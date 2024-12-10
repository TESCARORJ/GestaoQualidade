using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class RespostaAreasRiscosPrazoOriginal : IEntidade
    {
        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? Realizado { get; set; }
        public int Meta { get; set; }
    }
}
