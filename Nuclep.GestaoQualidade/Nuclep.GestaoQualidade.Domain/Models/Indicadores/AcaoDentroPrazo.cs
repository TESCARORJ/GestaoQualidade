using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.Net;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class AcaoDentroPrazo : IEntidade
    {
        public string? Ano { get; set; }
        public decimal PacPrazo { get; set; }
        public decimal TotalPacAberto { get; set; }

        public List<AcaoDentroPrazoMeta> MeseList;
    }
}
