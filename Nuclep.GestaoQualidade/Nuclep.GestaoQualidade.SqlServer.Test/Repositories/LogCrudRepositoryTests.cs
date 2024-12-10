using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using Nuclep.GestaoQualidade.SqlServer.Contexts;
using Nuclep.GestaoQualidade.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class LogCrudRepositoryTests
{
    private readonly DataContext _context;
    private readonly LogCrudRepository _repository;

    public LogCrudRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new DataContext(options);
        _repository = new LogCrudRepository(_context, _context, null, null);
    }

    
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        Usuario usuario3 = new Usuario
        {
            Id = 3,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        Usuario usuario4 = new Usuario
        {
            Id = 4,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entities = new List<LogCrud>
        {
            new LogCrud { Id = 3, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 3, UsuarioCadastro = usuario3},
            new LogCrud { Id = 4, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 4, UsuarioCadastro = usuario4}
        };
        _context.Set<LogCrud>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAll();

        result.Should().HaveCount(2);
    }
   
    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        var entity = new LogCrud { Id = 1, IsAtivo = true, DataHoraCadastro = DateTime.Now };

        await _repository.AddAsync(entity);

        var result = await _context.Set<LogCrud>().FindAsync(1);
        result.Should().NotBeNull();
        result?.Id.Should().Be(1);
    }
}
