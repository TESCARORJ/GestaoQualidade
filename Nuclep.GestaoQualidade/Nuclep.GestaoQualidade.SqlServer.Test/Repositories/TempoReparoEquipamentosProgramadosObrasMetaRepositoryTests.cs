﻿using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using Nuclep.GestaoQualidade.SqlServer.Contexts;
using Nuclep.GestaoQualidade.SqlServer.Repositories;

public class TempoReparoEquipamentosProgramadosObrasMetaRepositoryTests
{
    private DataContext _context;
    private TempoReparoEquipamentosProgramadosObrasMetaRepository _repository;

    //public TempoReparoEquipamentosProgramadosObrasMetaRepositoryTests()
    //{
    //    var options = new DbContextOptionsBuilder<DataContext>()
    //        .UseInMemoryDatabase(databaseName: "TestDatabase")
    //        .Options;

    //    _context = new DataContext(options);
    //    _repository = new TempoReparoEquipamentosProgramadosObrasMetaRepository(_context);
    //}


    private async Task ResetDatabaseAsync()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Garante um banco novo para cada teste
            .Options;

        _context = new DataContext(options);
        _repository = new TempoReparoEquipamentosProgramadosObrasMetaRepository(_context);

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

        var entity = new TempoReparoEquipamentosProgramadosObrasMeta { Id = 1, Meta = 100, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 1, UsuarioCadastro = usuario };
        _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().Add(entity);
        await _context.SaveChangesAsync();

        var result = await _repository.GetOneAsync(x => x.Id == 1);

        result.Should().NotBeNull();
        result?.Id.Should().Be(1);


        await _repository.DeleteAsync(entity);


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

        var entity = new TempoReparoEquipamentosProgramadosObrasMeta { Id = 2, Meta = 200, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 2, UsuarioCadastro = usuario };
        _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().Add(entity);
        await _context.SaveChangesAsync();

        var result = await _repository.GetByIdAsync(2);

        result.Should().NotBeNull();
        result?.Id.Should().Be(2);


        await _repository.DeleteAsync(entity);


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

        var entities = new List<TempoReparoEquipamentosProgramadosObrasMeta>
        {
            new TempoReparoEquipamentosProgramadosObrasMeta { Id = 3, Meta = 300, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 3, UsuarioCadastro = usuario3},
            new TempoReparoEquipamentosProgramadosObrasMeta { Id = 4, Meta = 400, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 4, UsuarioCadastro = usuario4}
        };
        _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAsync();

        result.Should().HaveCount(2);

        foreach (var item in entities)
        {
            await _repository.DeleteAsync(item);

        }
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

        var entities = new List<TempoReparoEquipamentosProgramadosObrasMeta>
        {
            new TempoReparoEquipamentosProgramadosObrasMeta { Id = 5, Meta = 500, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 5, UsuarioCadastro = usuario5 },
            new TempoReparoEquipamentosProgramadosObrasMeta { Id = 6, Meta = 600, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 6 , UsuarioCadastro = usuario6}
        };
        _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllUsarioLogadoAsync(5);

        result.Should().HaveCount(1);
        result.First().UsuarioCadastroId.Should().Be(5);

        foreach (var item in entities)
        {
            await _repository.DeleteAsync(item);

        }
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

        var entities = new List<TempoReparoEquipamentosProgramadosObrasMeta>
        {
            new TempoReparoEquipamentosProgramadosObrasMeta { Id = 7, Meta = 700, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 7, UsuarioCadastro = usuario7 },
            new TempoReparoEquipamentosProgramadosObrasMeta { Id = 8, Meta = 800, IsAtivo = false, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 8, UsuarioCadastro = usuario8 }
        };


        _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().AddRange(entities);

        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAtivosAsync();

        result.Should().HaveCount(1);
        result.First().IsAtivo.Should().BeTrue();

        foreach (var item in entities)
        {
            await _repository.DeleteAsync(item);

        }

    }

    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        await ResetDatabaseAsync();

        Usuario usuario9 = new Usuario
        {
            Id = 8,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entity = new TempoReparoEquipamentosProgramadosObrasMeta { Id = 1, Meta = 100, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 1, UsuarioCadastro = usuario9 };
        _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().Add(entity);
        await _context.SaveChangesAsync();

        var result = await _repository.GetByIdAsync(1);
        result.Should().NotBeNull();
        result?.Id.Should().Be(1);

        await _repository.DeleteAsync(entity);
    }

    [Fact]
    public async Task AddListAsync_ShouldAddEntities()
    {
        await ResetDatabaseAsync();

        var entities = new List<TempoReparoEquipamentosProgramadosObrasMeta>
        {
            new TempoReparoEquipamentosProgramadosObrasMeta { Id = 2, Meta = 200, IsAtivo = true, DataHoraCadastro = DateTime.Now },
            new TempoReparoEquipamentosProgramadosObrasMeta { Id = 3, Meta = 300, IsAtivo = true, DataHoraCadastro = DateTime.Now }
        };

        await _repository.AddListAsync(entities);

        var result = await _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().ToListAsync();
        result.Should().HaveCount(2);

        foreach (var item in entities)
        {
            await _repository.DeleteAsync(item);

        }
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateEntity()
    {
        await ResetDatabaseAsync();

        var entity = new TempoReparoEquipamentosProgramadosObrasMeta { Id = 4, Meta = 400, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().AddAsync(entity);
        await _context.SaveChangesAsync();

        entity.Meta = 500;
        await _repository.UpdateAsync(entity);

        var result = await _repository.GetByIdAsync(4);
        result?.Meta.Should().Be(500);

        await _repository.DeleteAsync(entity);

    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteEntity()
    {
        await ResetDatabaseAsync();

        var entity = new TempoReparoEquipamentosProgramadosObrasMeta { Id = 5, Meta = 500, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().AddAsync(entity);
        await _context.SaveChangesAsync();

        await _repository.DeleteAsync(entity);

        var result = await _repository.GetByIdAsync(5);
        result.Should().BeNull();
    }

    [Fact]
    public async Task VerifyExistsAsync_ShouldReturnTrueIfEntityExists()
    {
        await ResetDatabaseAsync();

        var entity = new TempoReparoEquipamentosProgramadosObrasMeta { Id = 6, Meta = 600, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<TempoReparoEquipamentosProgramadosObrasMeta>().AddAsync(entity);
        await _context.SaveChangesAsync();

        var exists = await _repository.VerifyExistsAsync(e => e.Id == 6);

        exists.Should().BeTrue();
    }
}
