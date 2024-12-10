using Nuclep.GestaoQualidade.Domain.Enumeradores;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class TaxaConformidadeDocumentosQualidadeMetaRequestDTO
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumAno Ano1 { get; set; }
        public EnumAno Ano2 { get; set; }
        public int Meta { get; set; }
    }
}
