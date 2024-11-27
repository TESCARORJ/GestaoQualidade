using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class CapacitacaoAreaContratos : IEntidade
    {

        public virtual string? Ano { get; set; }
        public virtual string? Trimestre { get; set; }
        public virtual decimal Realizado { get; set; }

        public List<CapacitacaoAreaContratosMeta> TrimestreList;
       


    }
}
