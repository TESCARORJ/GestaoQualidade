using Nuclep.GestaoQualidade.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class ItensCadastradosMais15DiasRequestDTO
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? QuantidadeItensCadastrados15Dias { get; set; }
        public long? QuantidadeItensCadastrados { get; set; }
        public int Meta { get; set; }
    }
}
