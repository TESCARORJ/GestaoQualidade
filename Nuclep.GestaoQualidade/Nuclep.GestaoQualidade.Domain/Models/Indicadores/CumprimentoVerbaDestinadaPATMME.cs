using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.Net;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class CumprimentoVerbaDestinadaPATMME : IEntidade
    {
        public EnumAno Ano { get; set; }
        public EnumSemestre Semestre { get; set; }
        public long? Realizado { get; set; }
        public int Meta { get; set; }

    }
}
