using Nuclep.GestaoQualidade.Domain.Enumeradores;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class DuracaoProcessoLicitacaoMetaRequestDTO
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumAno Ano { get; set; }
        public int Meta { get; set; }
    }
}
