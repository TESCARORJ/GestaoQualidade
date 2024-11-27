using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class RespostaAreasPrazoOriginal : IEntidade
    {


        public string? Ano { get; set; }
        public string? Triemeste { get; set; }
        public decimal Realizado { get; set; }

        public List<RespostaAreasPrazoOriginalMeta> TrimestreList;

    }
}
