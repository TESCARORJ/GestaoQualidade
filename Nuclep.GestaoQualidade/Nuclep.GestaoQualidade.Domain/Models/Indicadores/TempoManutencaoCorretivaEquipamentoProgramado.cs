using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class TempoManutencaoCorretivaEquipamentoProgramado : IEntidade
    {
        public string? Ano { get; set; }
        public string? Mes { get; set; }
        public decimal TotalHorasManutencaoCorretivaEquipamentosProgramados { get; set; }
        public decimal TotalHorasManutencaoPreventivaRealizada { get; set; }

        public List<TempoManutencaoCorretivaEquipamentoProgramadoMeta> MesList;
    }
}
