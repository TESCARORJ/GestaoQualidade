using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class DefeitoSoldagem : IEntidade
    {
        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos { get; set; }
        public long? TotalComprimentoSoldadoInspecionado { get; set; }

        [NotMapped]
        public long LocalidadeId { get; set; }
        public Localidade? Localidade { get; set; }
    }
}
