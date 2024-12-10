using Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs
{
    public class TaxaConformidadeDocumentosQualidadeResponseDTO
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumAno Ano1 { get; set; }
        public EnumAno Ano2 { get; set; }
        public long? TotalDocumentos { get; set; }
        public long? TotalDentroPrazo { get; set; }
        public int Meta { get; set; }

    }
}
