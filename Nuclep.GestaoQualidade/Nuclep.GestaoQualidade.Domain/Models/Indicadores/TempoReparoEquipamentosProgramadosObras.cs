using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class TempoReparoEquipamentosProgramadosObras : IEntidade
    {
        public EnumAno Ano { get; set; }
        public EnumMes Mes { get; set; }
        public long? TotalHoraManutencaoEquipamentoRealizadas { get; set; }
        public long? TotalHorasTrabalhadas { get; set; }
        public int Meta { get; set; }
    }
}
