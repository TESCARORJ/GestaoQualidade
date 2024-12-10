using Nuclep.GestaoQualidade.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class TaxaConformidadeDocumentosQualidadeRequestDTO
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
