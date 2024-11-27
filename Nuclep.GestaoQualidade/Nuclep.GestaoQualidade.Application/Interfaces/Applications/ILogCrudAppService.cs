using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ILogCrudAppService /*:  IDisposable*/
    {
        Task<List<LogCrudResponseDTO>> GetAllAsync();
    }
}
