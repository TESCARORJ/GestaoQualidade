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

public class UsuarioRepositoryTests
{
    private readonly DataContext _context;
    private readonly UsuarioRepository _repository;

    public UsuarioRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new DataContext(options);
        _repository = new UsuarioRepository(_context);
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

        var entity = new Usuario { Id = 1, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 1, UsuarioCadastro = usuario };
        _context.Set<Usuario>().Add(entity);
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

        var entity = new Usuario { Id = 2, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 2, UsuarioCadastro = usuario };
        _context.Set<Usuario>().Add(entity);
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

        var entities = new List<Usuario>
        {
            new Usuario { Id = 3, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 3, UsuarioCadastro = usuario3},
            new Usuario { Id = 4, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 4, UsuarioCadastro = usuario4}
        };
        _context.Set<Usuario>().AddRange(entities);
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

        var entities = new List<Usuario>
        {
            new Usuario { Id = 5, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 5, UsuarioCadastro = usuario5 },
            new Usuario { Id = 6, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 6 , UsuarioCadastro = usuario6}
        };
        _context.Set<Usuario>().AddRange(entities);
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

        var entities = new List<Usuario>
        {
            new Usuario { Id = 7, IsAtivo = true, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 7, UsuarioCadastro = usuario7 },
            new Usuario { Id = 8, IsAtivo = false, DataHoraCadastro = DateTime.Now, UsuarioCadastroId = 8, UsuarioCadastro = usuario8 }
        };
        _context.Set<Usuario>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAtivosAsync();

        result.Should().HaveCount(3);
        result.First().IsAtivo.Should().BeTrue();



    }

    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        var entity = new Usuario { Id = 1, NomeAD = "UserTeste", IsAtivo = true, DataHoraCadastro = DateTime.Now };

        await _repository.AddAsync(entity);

        var result = await _context.Set<Usuario>().FindAsync(1);
        result.Should().NotBeNull();
        result?.Id.Should().Be(1);
    }

    [Fact]
    public async Task AddListAsync_ShouldAddEntities()
    {
        var entities = new List<Usuario>
        {
            new Usuario { Id = 2, NomeAD = "UserTeste", IsAtivo = true, DataHoraCadastro = DateTime.Now },
            new Usuario { Id = 3, NomeAD = "UserTeste", IsAtivo = true, DataHoraCadastro = DateTime.Now }
        };

        await _repository.AddListAsync(entities);

        var result = await _context.Set<Usuario>().ToListAsync();
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateEntity()
    {
        var entity = new Usuario { Id = 4, NomeAD = "UserTeste", IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<Usuario>().AddAsync(entity);
        await _context.SaveChangesAsync();

        entity.NomeAD = "UpdatedUserTeste";
        await _repository.UpdateAsync(entity);

        var result = await _context.Set<Usuario>().FindAsync(4);
        result?.NomeAD.Should().Be("UpdatedUserTeste");
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteEntity()
    {
        var entity = new Usuario { Id = 5, NomeAD = "UserTeste", IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<Usuario>().AddAsync(entity);
        await _context.SaveChangesAsync();

        await _repository.DeleteAsync(entity);

        var result = await _context.Set<Usuario>().FindAsync(5);
        result.Should().BeNull();
    }

    [Fact]
    public async Task VerifyExistsAsync_ShouldReturnTrueIfEntityExists()
    {
        var entity = new Usuario { Id = 6, NomeAD = "UserTeste", IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<Usuario>().AddAsync(entity);
        await _context.SaveChangesAsync();

        var exists = await _repository.VerifyExistsAsync(e => e.Id == 6);

        exists.Should().BeTrue();
    }
}
