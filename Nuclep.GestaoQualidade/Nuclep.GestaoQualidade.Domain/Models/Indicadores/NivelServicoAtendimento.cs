using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class NivelServicoAtendimento : IEntidade
    {

        public string? Ano { get; set; }
        public string? Mes { get; set; }
        public decimal TotalDefeitosSoldaEncontradosEnsaiados { get; set; }
        public decimal TotalComprimentoSoldadoInspecionado { get; set; }

        public List<NivelServicoAtendimentoMeta> MeseList;
       
    }
}
