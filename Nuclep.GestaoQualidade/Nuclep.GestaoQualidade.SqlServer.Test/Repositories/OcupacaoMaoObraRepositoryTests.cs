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

public class OcupacaoMaoObraRepositoryTests
{
    private readonly DataContext _context;
    private readonly OcupacaoMaoObraRepository _repository;

    public OcupacaoMaoObraRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new DataContext(options);
        _repository = new OcupacaoMaoObraRepository(_context);
    }

    [Fact]
    public async Task GetOneAsync_ShouldReturnCorrectEntity()
    {

        Usuario usuario = new Usuario
        {
            Id = 1,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entity = new OcupacaoMaoObra { Id = 1, Meta = 100, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 1, UsuarioCadastro = usuario };
        _context.Set<OcupacaoMaoObra>().Add(entity);
        await _context.SaveChangesAsync();

        var result = await _repository.GetOneAsync(x => x.Id == 1);

        result.Should().NotBeNull();
        result?.Id.Should().Be(1);


    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectEntity()
    {
        Usuario usuario = new Usuario
        {
            Id = 2,
            NomeAD = "UserTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entity = new OcupacaoMaoObra { Id = 2, Meta = 200, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 2, UsuarioCadastro = usuario };
        _context.Set<OcupacaoMaoObra>().Add(entity);
        await _context.SaveChangesAsync();

        var result = await _repository.GetByIdAsync(2);

        result.Should().NotBeNull();
        result?.Id.Should().Be(2);



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

        var entities = new List<OcupacaoMaoObra>
        {
            new OcupacaoMaoObra { Id = 3, Meta = 300, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 3, UsuarioCadastro = usuario3},
            new OcupacaoMaoObra { Id = 4, Meta = 400, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 4, UsuarioCadastro = usuario4}
        };
        _context.Set<OcupacaoMaoObra>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAsync();

        result.Should().HaveCount(6);


    }

    [Fact]
    public async Task GetAllUsarioLogadoAsync_ShouldReturnEntitiesForLoggedUser()
    {
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

        var entities = new List<OcupacaoMaoObra>
        {
            new OcupacaoMaoObra { Id = 5, Meta = 500, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 5, UsuarioCadastro = usuario5 },
            new OcupacaoMaoObra { Id = 6, Meta = 600, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 6 , UsuarioCadastro = usuario6}
        };
        _context.Set<OcupacaoMaoObra>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllUsarioLogadoAsync(5);

        result.Should().HaveCount(1);
        result.First().UsuarioCadastroId.Should().Be(5);

    }

    [Fact]
    public async Task GetAllAtivosAsync_ShouldReturnActiveEntities()
    {

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

        var entities = new List<OcupacaoMaoObra>
        {
            new OcupacaoMaoObra { Id = 7, Meta = 700, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 7, UsuarioCadastro = usuario7 },
            new OcupacaoMaoObra { Id = 8, Meta = 800, IsAtivo = false, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 8, UsuarioCadastro = usuario8 }
        };
        _context.Set<OcupacaoMaoObra>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAtivosAsync();

        result.Should().HaveCount(3);
        result.First().IsAtivo.Should().BeTrue();



    }

    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        var entity = new OcupacaoMaoObra { Id = 1, Meta = 100, IsAtivo = true, DataHoraCadastro = DateTime.Now };

        await _repository.AddAsync(entity);

        var result = await _context.Set<OcupacaoMaoObra>().FindAsync(1);
        result.Should().NotBeNull();
        result?.Id.Should().Be(1);
    }

    [Fact]
    public async Task AddListAsync_ShouldAddEntities()
    {
        var entities = new List<OcupacaoMaoObra>
        {
            new OcupacaoMaoObra { Id = 2, Meta = 200, IsAtivo = true, DataHoraCadastro = DateTime.Now },
            new OcupacaoMaoObra { Id = 3, Meta = 300, IsAtivo = true, DataHoraCadastro = DateTime.Now }
        };

        await _repository.AddListAsync(entities);

        var result = await _context.Set<OcupacaoMaoObra>().ToListAsync();
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateEntity()
    {
        var entity = new OcupacaoMaoObra { Id = 4, Meta = 400, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<OcupacaoMaoObra>().AddAsync(entity);
        await _context.SaveChangesAsync();

        entity.Meta = 500;
        await _repository.UpdateAsync(entity);

        var result = await _context.Set<OcupacaoMaoObra>().FindAsync(4);
        result?.Meta.Should().Be(500);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteEntity()
    {
        var entity = new OcupacaoMaoObra { Id = 5, Meta = 500, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<OcupacaoMaoObra>().AddAsync(entity);
        await _context.SaveChangesAsync();

        await _repository.DeleteAsync(entity);

        var result = await _context.Set<OcupacaoMaoObra>().FindAsync(5);
        result.Should().BeNull();
    }

    [Fact]
    public async Task VerifyExistsAsync_ShouldReturnTrueIfEntityExists()
    {
        var entity = new OcupacaoMaoObra { Id = 6, Meta = 600, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<OcupacaoMaoObra>().AddAsync(entity);
        await _context.SaveChangesAsync();

        var exists = await _repository.VerifyExistsAsync(e => e.Id == 6);

        exists.Should().BeTrue();
    }
}
