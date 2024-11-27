using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Models
{
    /// <summary>
    /// Modelo de dados para gravação dos logs de cliente
    /// </summary>
    public class LogModel
    {
        public long? Id { get; set; }
        public TipoOperacao? TipoOperacao { get; set; }
        public DateTime? DataOperacao { get; set; }
        public long? ClienteId { get; set; }
        public string? DadosCliente { get; set; }
    }

    public enum TipoOperacao
    {
        Add = 1,
        Update = 2,
        Delete = 3
    }
}
