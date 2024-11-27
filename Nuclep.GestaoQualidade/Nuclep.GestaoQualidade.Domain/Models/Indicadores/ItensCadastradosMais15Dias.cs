using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.Net;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class ReducaoRNC : IEntidade
    {

        public string? Ano { get; set; }
        public decimal TotalRNC { get; set; }
        public decimal TotalPecasProduzidas { get; set; }

        public List<ReducaoRNCMeta> MesList;
       

    }
}
