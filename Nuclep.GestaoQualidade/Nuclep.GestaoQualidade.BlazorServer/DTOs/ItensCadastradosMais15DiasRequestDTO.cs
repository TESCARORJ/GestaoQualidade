using Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs
{
    public class ItensCadastradosMais15DiasRequestDTO
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumAno Ano { get; set; }
        public EnumMes Mes { get; set; }
        public long? QuantidadeItensCadastrados15Dias { get; set; }
        public long? QuantidadeItensCadastrados { get; set; }
        public int Meta { get; set; }

    }
}
