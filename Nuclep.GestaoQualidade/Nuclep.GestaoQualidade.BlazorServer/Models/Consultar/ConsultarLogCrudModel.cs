using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarLogCrudModel : IBaseModel
    {
        public List<LogCrudResponseDTO>? LogCrudList { get; set; }

        public long IdReferencia { get; set; }
        public LogTipo LogTipo { get; set; }
        public long LogTabelaId { get; set; }
        public string? LogTabelaNome { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }

    }
}
