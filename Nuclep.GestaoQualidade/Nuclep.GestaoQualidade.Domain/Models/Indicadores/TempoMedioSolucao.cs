using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.Net;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class TempoMedioSolucao : IEntidade
    {
        public string? Ano { get; set; }
        public string? Mes { get; set; }
        public decimal Atividade1 { get; set; }
        public decimal Atividade2 { get; set; }

        public List<TempoMedioSolucaoMeta> MesList;
       
    }
}
