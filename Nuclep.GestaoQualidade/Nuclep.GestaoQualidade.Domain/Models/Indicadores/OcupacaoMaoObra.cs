using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class OcupacaoMaoObra : IEntidade
    {

        public string? Ano { get; set; }
        public string? Mes { get; set; }
        public decimal TempoEfetivoFabril { get; set; }
        public decimal TempoDisponivelFabril { get; set; }

        public List<OcupacaoMaoObraMeta> MesList;
        


    }
}
