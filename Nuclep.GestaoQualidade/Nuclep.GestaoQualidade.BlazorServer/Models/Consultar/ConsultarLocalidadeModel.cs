using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarLocalidadeModel : IBaseModel
    {
        public List<LocalidadeResponseDTO>? LocalidadeList { get; set; }
        public string? Nome { get; set; }
    }
}
