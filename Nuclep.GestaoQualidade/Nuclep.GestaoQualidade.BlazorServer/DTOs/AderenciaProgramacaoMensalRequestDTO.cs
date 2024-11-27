using Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs
{
    public class AderenciaProgramacaoMensalRequestDTO 
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? TotalAtividadesProgramadas { get; set; }
        public long? AtividadesRealizadas { get; set; }
        public long? AtividadesCanceladas { get; set; }
        public int Meta { get; set; }

    }
}
