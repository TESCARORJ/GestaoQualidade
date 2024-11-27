using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class TempoReparoEquipamentosProgramadosObrasMeta : IEntidade
    {
        public string? Ano { get; set; }
        public string? Mes { get; set; }
        public int Meta { get; set; }

    }
}
