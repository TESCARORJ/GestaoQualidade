using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class SatisfacaoClientesAreaResponsavel : IEntidade
    {

        public string? Ano { get; set; }
        public decimal Realizado { get; set; }
        public int Meta { get; set; }


    }
}
