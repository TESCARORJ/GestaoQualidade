using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class EventosAtraso : IEntidade
    {

        public string? Ano { get; set; }
        public decimal NumeroEventosAtraso { get; set; }
        public decimal NumeroTotalEventos { get; set; }

        public List<EventosAtrasoMeta> MesList;

    }
}
