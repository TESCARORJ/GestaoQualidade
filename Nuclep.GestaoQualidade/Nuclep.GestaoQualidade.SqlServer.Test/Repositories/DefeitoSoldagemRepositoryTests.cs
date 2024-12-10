using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
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

public class DefeitoSoldagemRepositoryTests
{
    private DataContext _context;
    private DefeitoSoldagemRepository _repository;

    private async Task ResetDatabaseAsync()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Garante um banco novo para cada teste
            .Options;

        _context = new DataContext(options);
        _repository = new DefeitoSoldagemRepository(_context);

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

        Localidade localidade = new Localidade
        {
            Id = 1,
            Nome = "LocalidadeTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entity = new DefeitoSoldagem
        {
            Id = 1,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            Localidade = localidade,
            LocalidadeId = 1,
            UsuarioCadastroId = 1,
            UsuarioCadastro = usuario
        };
        _context.Set<DefeitoSoldagem>().Add(entity);
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
        Localidade localidade = new Localidade
        {
            Id = 1,
            Nome = "LocalidadeTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };

        var entity = new DefeitoSoldagem
        {
            Id = 2,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            Localidade = localidade,
            LocalidadeId = 1,
            UsuarioCadastroId = 2,
            UsuarioCadastro = usuario
        };


        _context.Set<DefeitoSoldagem>().Add(entity);
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

        Localidade localidade = new Localidade
        {
            Id = 1,
            Nome = "LocalidadeTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };



        var entities = new List<DefeitoSoldagem>
        {
            new DefeitoSoldagem {
            Id = 3,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            Localidade = localidade,
            LocalidadeId = 1,
            UsuarioCadastroId = 3,
            UsuarioCadastro = usuario3
            },
            new DefeitoSoldagem {
            Id = 4,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            Localidade = localidade,
            LocalidadeId = 1,
            UsuarioCadastroId = 4,
            UsuarioCadastro = usuario4
            }
        };
        _context.Set<DefeitoSoldagem>().AddRange(entities);
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

        Localidade localidade = new Localidade
        {
            Id = 1,
            Nome = "LocalidadeTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };



        var entities = new List<DefeitoSoldagem>
        {
            new DefeitoSoldagem {
            Id = 5,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            Localidade = localidade,
            LocalidadeId = 1,
            UsuarioCadastroId = 3,
            UsuarioCadastro = usuario5
            },
            new DefeitoSoldagem {
            Id = 6,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            Localidade = localidade,
            LocalidadeId = 1,
            UsuarioCadastroId = 4,
            UsuarioCadastro = usuario6
            }
        };
        _context.Set<DefeitoSoldagem>().AddRange(entities);
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

        Localidade localidade = new Localidade
        {
            Id = 1,
            Nome = "LocalidadeTeste",
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now
        };



        var entities = new List<DefeitoSoldagem>
        {
            new DefeitoSoldagem {
            Id = 7,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            Localidade = localidade,
            LocalidadeId = 1,
            UsuarioCadastroId = 3,
            UsuarioCadastro = usuario7
            },
            new DefeitoSoldagem {
            Id = 8,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            Localidade = localidade,
            LocalidadeId = 1,
            UsuarioCadastroId = 4,
            UsuarioCadastro = usuario8
            }
        };

        _context.Set<DefeitoSoldagem>().AddRange(entities);
        await _context.SaveChangesAsync();

        var result = await _repository.GetAllAtivosAsync();

        result.Should().HaveCount(3);
        result.First().IsAtivo.Should().BeTrue();



    }

    [Fact]
    public async Task AddAsync_ShouldAddEntity()
    {
        await ResetDatabaseAsync();

        var entity = new DefeitoSoldagem
        {
            Id = 1,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            LocalidadeId = 1,
            UsuarioCadastroId = 1
        };

        await _repository.AddAsync(entity);

        var result = await _context.Set<DefeitoSoldagem>().FindAsync(1);
        result.Should().NotBeNull();
        result?.Id.Should().Be(1);
    }

    [Fact]
    public async Task AddListAsync_ShouldAddEntities()
    {
        await ResetDatabaseAsync();

        var entities = new List<DefeitoSoldagem>
        {
            new DefeitoSoldagem
            {
                Id = 2,
                Mes = EnumMes.Janeiro,
                Ano = EnumAno.Ano2024,
                TotalComprimentoSoldadoInspecionado = 10,
                TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
                IsAtivo = true,
                DataHoraCadastro = DateTime.Now,
                LocalidadeId = 1,
                UsuarioCadastroId = 2
            },
            new DefeitoSoldagem
            {
                Id = 3,
                Mes = EnumMes.Janeiro,
                Ano = EnumAno.Ano2024,
                TotalComprimentoSoldadoInspecionado = 10,
                TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
                IsAtivo = true,
                DataHoraCadastro = DateTime.Now,
                LocalidadeId = 1,
                UsuarioCadastroId = 3
            }
        };

        await _repository.AddListAsync(entities);

        var result = await _context.Set<DefeitoSoldagem>().ToListAsync();
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateEntity()
    {
        await ResetDatabaseAsync();

        var entity = new DefeitoSoldagem
        {
            Id = 4,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            LocalidadeId = 1,
            UsuarioCadastroId = 4
        };
        await _context.Set<DefeitoSoldagem>().AddAsync(entity);
        await _context.SaveChangesAsync();

        entity.TotalComprimentoSoldadoInspecionado = 15;
        await _repository.UpdateAsync(entity);

        var result = await _context.Set<DefeitoSoldagem>().FindAsync(4);
        result?.TotalComprimentoSoldadoInspecionado.Should().Be(15);
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteEntity()
    {
        await ResetDatabaseAsync();

        var entity = new DefeitoSoldagem
        {
            Id = 5,
            Mes = EnumMes.Janeiro,
            Ano = EnumAno.Ano2024,
            TotalComprimentoSoldadoInspecionado = 10,
            TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = 20,
            IsAtivo = true,
            DataHoraCadastro = DateTime.Now,
            LocalidadeId = 1,
            UsuarioCadastroId = 5
        };
        await _context.Set<DefeitoSoldagem>().AddAsync(entity);
        await _context.SaveChangesAsync();

        await _repository.DeleteAsync(entity);

        var result = await _context.Set<DefeitoSoldagem>().FindAsync(5);
        result.Should().BeNull();
    }

    [Fact]
    public async Task VerifyExistsAsync_ShouldReturnTrueIfEntityExists()
    {
        await ResetDatabaseAsync();

        var entity = new AcaoCorrecaoAvaliadaEficazMeta { Id = 6, Meta = 600, IsAtivo = true, DataHoraCadastro = DateTime.Now };
        await _context.Set<AcaoCorrecaoAvaliadaEficazMeta>().AddAsync(entity);
        await _context.SaveChangesAsync();

        var exists = await _repository.VerifyExistsAsync(e => e.Id == 6);

        exists.Should().BeTrue();
    }
}