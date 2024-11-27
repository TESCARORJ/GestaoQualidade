using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class LogCrudResponseDTO
    {
        public long Id { get; set; }
        public long IdReferencia { get; set; }
        public LogTipo LogTipo { get; set; }
        public long LogTabelaId { get; set; }
        public string? LogTabelaNome { get; set; }
        public long LogCrudId { get; set; }
        public LogCrud LogCrud { get; set; }
        public string Descricao { get; set; }

       
    }
}
