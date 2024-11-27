using System.ComponentModel.DataAnnotations.Schema;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Interface
{
    public class IBaseModel
    {
        public long Id { get; set; }
        public string? NomeAD { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
    }
}
