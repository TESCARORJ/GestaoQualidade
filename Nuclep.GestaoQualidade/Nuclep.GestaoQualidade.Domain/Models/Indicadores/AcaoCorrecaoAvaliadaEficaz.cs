using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.Net;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class AcaoCorrecaoAvaliadaEficaz : IEntidade
    {
        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? TotalAbertura { get; set; }
        public long? TotalFechamento { get; set; }
        public long? TotalTratamentoEficaz { get; set; }
        public int Meta { get; set; }

    }
}
