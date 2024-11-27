using Nuclep.GestaoQualidade.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class LocalidadeRequestDTO
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public bool IsAtivo { get; set; }
        public long UsuarioCadastroId { get; set; }
        public string? UsuarioCadastroName { get; set; }
        [JsonIgnore]
        public DateTime DataHoraCadastro { get; set; }
      
       
    }
}
