using Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs
{
    public class RejeicaoMateriaisRequestDTO 
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumAno Ano { get; set; }
        public EnumTrimestre Trimestre { get; set; }
        public long? TotalCTIsRejeitados { get; set; }
        public long? TotalCTIsFinalizados { get; set; }
        public int Meta { get; set; }

    }
}
