using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class CumprimentoEtapasPACDentroPrazo : IEntidade
    {

        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? PACPrazo { get; set; }
        public long? TotalPACAberto { get; set; }
        public int Meta { get; set; }

    }
}
