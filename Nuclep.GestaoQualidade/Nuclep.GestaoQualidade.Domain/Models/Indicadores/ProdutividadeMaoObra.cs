using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class ProdutividadeMaoObra : IEntidade
    {
        public string? Ano { get; set; }
        public string? Mes { get; set; }
        public decimal TempoTotalFaturavel { get; set; }
        public decimal TempoDisponivelTotal { get; set; }
        public decimal Perdas { get; set; }

        public List<ProdutividadeMaoObraMeta> MesList;
      


    }
}
