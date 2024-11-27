using Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs
{
    public class CumprimentoEtapasPACDentroPrazoRequestDTO 
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? PACPrazo { get; set; }
        public long? TotalPACAberto { get; set; }
        public int Meta { get; set; }

    }
}
