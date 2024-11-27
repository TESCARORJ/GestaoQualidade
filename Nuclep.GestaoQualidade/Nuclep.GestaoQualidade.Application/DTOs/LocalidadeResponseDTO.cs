using Nuclep.GestaoQualidade.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class LocalidadeResponseDTO
    {   
        public long Id { get; set; }
        public string? Nome { get; set; }
        public bool IsAtivo { get; set; }
        public long UsuarioCadastroId { get; set; }
        public string? UsuarioCadastroName { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        
    }
}
