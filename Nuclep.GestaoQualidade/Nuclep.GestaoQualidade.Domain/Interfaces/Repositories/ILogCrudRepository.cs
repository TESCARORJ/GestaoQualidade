﻿using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ILogCrudRepository : IBaseRepository<LogCrud, long>
    {
        Task AddAsync(LogCrud entity);
        Task<List<LogCrud>> GetAll();
    }
}
