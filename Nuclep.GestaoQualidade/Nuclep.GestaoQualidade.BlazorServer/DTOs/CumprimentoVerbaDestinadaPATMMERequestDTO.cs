using Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs
{
    public class CumprimentoVerbaDestinadaPATMMERequestDTO 
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }       
        public EnumAno Ano { get; set; }
        public EnumSemestre Semestre { get; set; }
        public long? Realizado { get; set; }
        public int Meta { get; set; }

    }
}
