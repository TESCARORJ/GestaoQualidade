using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class SatisfacaoUsuarioResponseDTO
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? Atividade1 { get; set; }
        public long? Atividade2 { get; set; }
        public int Meta { get; set; }
    }
}
