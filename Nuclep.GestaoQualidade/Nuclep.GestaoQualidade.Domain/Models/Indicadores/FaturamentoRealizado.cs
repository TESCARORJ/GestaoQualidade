using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class FaturamentoRealizado : IEntidade
    {
        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? SomatorioFaturamentoRealizadoTrimestre { get; set; }
        public long? PrevistoJaneiroAnoCorrente { get; set; }
        public int Meta { get; set; }
    }
}
