using Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs
{
    public class LocalidadeRequestDTO : IBaseDTO
    {
        public string? Nome { get; set; }
        
    }
}
