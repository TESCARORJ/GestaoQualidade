using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.Net;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class GestaoProcessosPessoasPrevistoPAT : IEntidade
    {

        public string? Ano { get; set; }
        public decimal Realizado { get; set; }

        public List<GestaoProcessosPessoasPrevistoPATMeta> TrimestreList;
       
    }
}
