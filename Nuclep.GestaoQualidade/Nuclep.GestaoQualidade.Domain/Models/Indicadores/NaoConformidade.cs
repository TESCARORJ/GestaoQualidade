using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.Net;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class NaoConformidade : IEntidade
    {
        public EnumAno Ano { get; set; }
        public EnumMes Mes { get; set; }
        public long? Atividade1 { get; set; }
        public long? Atividade2 { get; set; }
        public int Meta { get; set; }

    }
}
