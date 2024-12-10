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

public class LogTabelaRepositoryTests
{
    private readonly DataContext _context;
    private readonly LogTabelaRepository _repository;

    public LogTabelaRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new DataContext(options);
        _repository = new LogTabelaRepository(_context);
    }

    [Fact]
    public async Task GetOneAsync_ShouldReturnCorrectEntity()
    {
        var entity = new LogTabela { Id = 1, Nome = "Teste", Descricao = "Descricao Teste" };
        _context.Set<LogTabela>().Add(entity);
        await _context.SaveChangesAsync();

        var result = await _repository.GetOneAsync(x => x.Id == 1);

        result.Should().NotBeNull();
        result?.Id.Should().Be(1);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectEntity()
    {
        var entity = new LogTabela { Id = 2, Nome = "Teste 2", Descricao = "Descricao Teste 2" };
        _context.Set<LogTabela>().Add(entity);
        await _context.SaveChangesAsync();

        var result = await _repository.GetByIdAsync(2);

        result.Should().NotBeNull();
        result?.Id.Should().Be(2);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        var entities = new List<LogTabela>
        {
            new LogTabela { Id = 3, Nome = "Teste 3", Descricao = "Descricao Teste 3" },
            new LogTabela { Id = 4, Nome = "Teste 4", Descricao = "Descricao Teste 4" }
        };
        _context.Set<LogTabela>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAsync();

        result.Should().HaveCount(2);
    }
}
