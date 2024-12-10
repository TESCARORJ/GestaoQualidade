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

public class CumprimentoEtapasPACDentroPrazoRepositoryTests
{
    private DataContext _context;
    private CumprimentoEtapasPACDentroPrazoRepository _repository;

    private async Task ResetDatabaseAsync()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Garante um banco novo para cada teste
            .Options;

        _context = new DataContext(options);
        _repository = new CumprimentoEtapasPACDentroPrazoRepository(_context);

        // Opcional: Use SaveChangesAsync se for necessário inicializar algum estado no banco
        await Task.CompletedTask;
    }

    [Fact]
    public async Task GetOneAsync_ShouldReturnCorrectEntity()
    {
        await ResetDatabaseAsync();

        Usuario usuario = new Usuario
        {
            Id = 1,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entity = new CumprimentoEtapasPACDentroPrazo { Id = 1, PACPrazo = 100, TotalPACAberto = 200, Meta = 100, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 1, UsuarioCadastro = usuario };
        _context.Set<CumprimentoEtapasPACDentroPrazo>().Add(entity);
        await _context.SaveChangesAsync();

        var result = await _repository.GetOneAsync(x => x.Id == 1);

        result.Should().NotBeNull();
        result?.Id.Should().Be(1);


    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectEntity()
    {
        await ResetDatabaseAsync();

        Usuario usuario = new Usuario
        {
            Id = 2,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entity = new CumprimentoEtapasPACDentroPrazo { Id = 2, PACPrazo = 100, TotalPACAberto = 200, Meta = 200, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 2, UsuarioCadastro = usuario };
        _context.Set<CumprimentoEtapasPACDentroPrazo>().Add(entity);
        await _context.SaveChangesAsync();

        var result = await _repository.GetByIdAsync(2);

        result.Should().NotBeNull();
        result?.Id.Should().Be(2);



    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        await ResetDatabaseAsync();

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

        var entities = new List<CumprimentoEtapasPACDentroPrazo>
        {
            new CumprimentoEtapasPACDentroPrazo { Id = 3, PACPrazo = 100, TotalPACAberto = 200, Meta = 300, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 3, UsuarioCadastro = usuario3},
            new CumprimentoEtapasPACDentroPrazo { Id = 4, PACPrazo = 100, TotalPACAberto = 200, Meta = 400, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 4, UsuarioCadastro = usuario4}
        };
        _context.Set<CumprimentoEtapasPACDentroPrazo>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAsync();

        result.Should().HaveCount(6);


    }

    [Fact]
    public async Task GetAllUsarioLogadoAsync_ShouldReturnEntitiesForLoggedUser()
    {
        await ResetDatabaseAsync();

        Usuario usuario5 = new Usuario
        {
            Id = 5,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        Usuario usuario6 = new Usuario
        {
            Id = 6,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entities = new List<CumprimentoEtapasPACDentroPrazo>
        {
            new CumprimentoEtapasPACDentroPrazo { Id = 5, PACPrazo = 100, TotalPACAberto = 200, Meta = 500, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 5, UsuarioCadastro = usuario5 },
            new CumprimentoEtapasPACDentroPrazo { Id = 6, PACPrazo = 100, TotalPACAberto = 200, Meta = 600, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 6 , UsuarioCadastro = usuario6}
        };
        _context.Set<CumprimentoEtapasPACDentroPrazo>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllUsarioLogadoAsync(5);

        result.Should().HaveCount(1);
        result.First().UsuarioCadastroId.Should().Be(5);

    }

    [Fact]
    public async Task GetAllAtivosAsync_ShouldReturnActiveEntities()
    {
        await ResetDatabaseAsync();

        Usuario usuario7 = new Usuario
        {
            Id = 7,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };
        Usuario usuario8 = new Usuario
        {
            Id = 8,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entities = new List<CumprimentoEtapasPACDentroPrazo>
        {
            new CumprimentoEtapasPACDentroPrazo { Id = 7, PACPrazo = 100, TotalPACAberto = 200, Meta = 700, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 7, UsuarioCadastro = usuario7 },
            new CumprimentoEtapasPACDentroPrazo { Id = 8, PACPrazo = 100, TotalPACAberto = 200, Meta = 800, IsAtivo = false, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 8, UsuarioCadastro = usuario8 }
        };
        _context.Set<CumprimentoEtapasPACDentroPrazo>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAtivosAsync();

        result.Should().HaveCount(3);
        result.First().IsAtivo.Should().BeTrue();



    }

    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        await ResetDatabaseAsync();

        var entity = new CumprimentoEtapasPACDentroPrazo { Id = 1, PACPrazo = 100, TotalPACAberto = 200, Meta = 100, IsAtivo = true, DataHoraCadastro = DateTime.Now };

        await _repository.AddAsync(entity);

        var result = await _context.Set<CumprimentoEtapasPACDentroPrazo>().FindAsync(1);
        result.Should().NotBeNull();
        result?.Id.Should().Be(1);
    }

    [Fact]
    public async Task AddListAsync_ShouldAddEntities()
    {
        await ResetDatabaseAsync();

        var entities = new List<CumprimentoEtapasPACDentroPrazo>
        {
            new CumprimentoEtapasPACDentroPrazo { Id = 2, Meta = 200, IsAtivo = true, DataHoraCadastro = DateTime.Now },
            new CumprimentoEtapasPACDentroPrazo { Id = 3, Meta = 300, IsAtivo = true, DataHoraCadastro = DateTime.Now }
        };

        await _repository.AddListAsync(entities);

        var result = await _context.Set<CumprimentoEtapasPACDentroPrazo>().ToListAsync();
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateEntity()
    {
        await ResetDatabaseAsync();

        var entity = new CumprimentoEtapasPACDentroPrazo { Id = 4, Meta = 400, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<CumprimentoEtapasPACDentroPrazo>().AddAsync(entity);
        await _context.SaveChangesAsync();

        entity.Meta = 500;
        await _repository.UpdateAsync(entity);

        var result = await _context.Set<CumprimentoEtapasPACDentroPrazo>().FindAsync(4);
        result?.Meta.Should().Be(500);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteEntity()
    {
        await ResetDatabaseAsync();

        var entity = new CumprimentoEtapasPACDentroPrazo { Id = 5, Meta = 500, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<CumprimentoEtapasPACDentroPrazo>().AddAsync(entity);
        await _context.SaveChangesAsync();

        await _repository.DeleteAsync(entity);

        var result = await _context.Set<CumprimentoEtapasPACDentroPrazo>().FindAsync(5);
        result.Should().BeNull();
    }

    [Fact]
    public async Task VerifyExistsAsync_ShouldReturnTrueIfEntityExists()
    {
        await ResetDatabaseAsync();

        var entity = new CumprimentoEtapasPACDentroPrazo { Id = 6, Meta = 600, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<CumprimentoEtapasPACDentroPrazo>().AddAsync(entity);
        await _context.SaveChangesAsync();

        var exists = await _repository.VerifyExistsAsync(e => e.Id == 6);

        exists.Should().BeTrue();
    }
}
