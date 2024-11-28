using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class OcupacaoMaoObra : IEntidade
    {

        public EnumAno Ano { get; set; }
        public EnumMes Mes { get; set; }
        public long? TempoEfetivoFabril { get; set; }
        public long? TempoDisponivelFabril { get; set; }
        public int Meta { get; set; }


    }
}
