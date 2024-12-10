using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;
using System.Net;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class ItensCadastradosMais15Dias : IEntidade
    {
        public EnumAno Ano { get; set; }
        public EnumMes Mes { get; set; }
        public long? QuantidadeItensCadastrados15Dias { get; set; }
        public long? QuantidadeItensCadastrados { get; set; }
        public long? Atividade2 { get; set; }
        public int Meta { get; set; }

    }
}
