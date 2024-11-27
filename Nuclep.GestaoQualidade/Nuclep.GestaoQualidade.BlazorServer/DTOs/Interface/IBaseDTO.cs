using System.ComponentModel.DataAnnotations.Schema;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface
{
    public class IBaseDTO
    {
        public long Id { get; set; }
        public string? NomeAD { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public string? UsuarioCadastroName { get; set; }

    }
}
