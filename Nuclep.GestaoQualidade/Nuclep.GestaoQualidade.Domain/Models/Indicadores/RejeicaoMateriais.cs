using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class RejeicaoMateriais : IEntidade
    {
        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? TotalCTIsRejeitados { get; set; }
        public long? TotalCTIsFinalizados { get; set; }
        public int Meta { get; set; }
    }
}
