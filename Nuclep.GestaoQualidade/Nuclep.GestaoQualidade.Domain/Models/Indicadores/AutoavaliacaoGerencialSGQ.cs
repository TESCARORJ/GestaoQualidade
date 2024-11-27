using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class AutoavaliacaoGerencialSGQ : IEntidade
    {
        public EnumAno Ano { get; set; }
        public long? Realizado { get; set; }
        public int Meta { get; set; }


    }
}
