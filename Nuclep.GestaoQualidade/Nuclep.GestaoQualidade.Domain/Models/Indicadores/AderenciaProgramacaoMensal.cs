using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class AderenciaProgramacaoMensal : IEntidade
    {

        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? TotalAtividadesProgramadas { get; set; }
        public long? AtividadesRealizadas { get; set; }
        public long? AtividadesCanceladas { get; set; }
        public int Meta { get; set; }

    }
}
