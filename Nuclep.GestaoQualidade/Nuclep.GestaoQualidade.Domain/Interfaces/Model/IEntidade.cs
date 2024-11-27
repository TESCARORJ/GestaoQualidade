using Nuclep.GestaoQualidade.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Model
{
    public class IEntidade
    {
        public long Id { get; set; }
        public string? NomeAD { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        
        [NotMapped]
        public long UsuarioCadastroId { get; set; }
        public Usuario? UsuarioCadastro { get; set; }

    }
}
