using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class TempoReparoEquipamentosProgramadosObras : IEntidade
    {
        public string? Ano { get; set; }
        public string? Mes { get; set; }
        public decimal TotalHoraManutencaoEquipamentoRealizadas { get; set; }
        public decimal TotalHorasTrabalhadas { get; set; }

        public List<TempoReparoEquipamentosProgramadosObrasMeta> MesList;
    }
}
