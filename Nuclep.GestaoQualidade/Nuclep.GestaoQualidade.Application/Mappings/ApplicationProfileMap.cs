using AutoMapper;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Mappings
{
    public class ApplicationProfileMap : Profile
    {
        private IDefeitoSoldagemRepository _defeitoSoldagemRepository;

        public ApplicationProfileMap(IDefeitoSoldagemRepository defeitoSoldagemRepository)
        {
            _defeitoSoldagemRepository = defeitoSoldagemRepository;
        }

        public ApplicationProfileMap()
        {
            CreateMap<AderenciaProgramacaoMensalRequestDTO, AderenciaProgramacaoMensal>().ReverseMap();
            CreateMap<AderenciaProgramacaoMensal, AderenciaProgramacaoMensalResponseDTO>().ReverseMap();
            CreateMap<AderenciaProgramacaoMensalMetaRequestDTO, AderenciaProgramacaoMensalMeta>().ReverseMap();
            CreateMap<AderenciaProgramacaoMensalMeta, AderenciaProgramacaoMensalMetaResponseDTO>().ReverseMap();

            CreateMap<AcaoCorrecaoAvaliadaEficazRequestDTO, AcaoCorrecaoAvaliadaEficaz>().ReverseMap();
            CreateMap<AcaoCorrecaoAvaliadaEficaz, AcaoCorrecaoAvaliadaEficazResponseDTO>().ReverseMap();
            CreateMap<AcaoCorrecaoAvaliadaEficazMetaRequestDTO, AcaoCorrecaoAvaliadaEficazMeta>().ReverseMap();
            CreateMap<AcaoCorrecaoAvaliadaEficazMeta, AcaoCorrecaoAvaliadaEficazMetaResponseDTO>().ReverseMap();

            CreateMap<FaturamentoRealizadoRequestDTO, FaturamentoRealizado>().ReverseMap();
            CreateMap<FaturamentoRealizado, FaturamentoRealizadoResponseDTO>().ReverseMap();
            CreateMap<FaturamentoRealizadoMetaRequestDTO, FaturamentoRealizadoMeta>().ReverseMap();
            CreateMap<FaturamentoRealizadoMeta, FaturamentoRealizadoMetaResponseDTO>().ReverseMap();

            CreateMap<DuracaoProcessoLicitacaoRequestDTO, DuracaoProcessoLicitacao>().ReverseMap();
            CreateMap<DuracaoProcessoLicitacao, DuracaoProcessoLicitacaoResponseDTO>().ReverseMap();
            CreateMap<DuracaoProcessoLicitacaoMetaRequestDTO, DuracaoProcessoLicitacaoMeta>().ReverseMap();
            CreateMap<DuracaoProcessoLicitacaoMeta, DuracaoProcessoLicitacaoMetaResponseDTO>().ReverseMap();

            CreateMap<AutoavaliacaoGerencialSGQRequestDTO, AutoavaliacaoGerencialSGQ>().ReverseMap();
            CreateMap<AutoavaliacaoGerencialSGQ, AutoavaliacaoGerencialSGQResponseDTO>().ReverseMap();
            CreateMap<AutoavaliacaoGerencialSGQMetaRequestDTO, AutoavaliacaoGerencialSGQMeta>().ReverseMap();
            CreateMap<AutoavaliacaoGerencialSGQMeta, AutoavaliacaoGerencialSGQMetaResponseDTO>().ReverseMap();

            CreateMap<CumprimentoEtapasPACDentroPrazoRequestDTO, CumprimentoEtapasPACDentroPrazo>().ReverseMap();
            CreateMap<CumprimentoEtapasPACDentroPrazo, CumprimentoEtapasPACDentroPrazoResponseDTO>().ReverseMap();
            CreateMap<CumprimentoEtapasPACDentroPrazoMetaRequestDTO, CumprimentoEtapasPACDentroPrazoMeta>().ReverseMap();
            CreateMap<CumprimentoEtapasPACDentroPrazoMeta, CumprimentoEtapasPACDentroPrazoMetaResponseDTO>().ReverseMap();

            CreateMap<CumprimentoVerbaDestinadaPATMMERequestDTO, CumprimentoVerbaDestinadaPATMME>().ReverseMap();
            CreateMap<CumprimentoVerbaDestinadaPATMME, CumprimentoVerbaDestinadaPATMMEResponseDTO>().ReverseMap();
            CreateMap<CumprimentoVerbaDestinadaPATMMEMetaRequestDTO, CumprimentoVerbaDestinadaPATMMEMeta>().ReverseMap();
            CreateMap<CumprimentoVerbaDestinadaPATMMEMeta, CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>().ReverseMap();
             
            CreateMap<EficaciaTreinamentoRequestDTO, EficaciaTreinamento>().ReverseMap();
            CreateMap<EficaciaTreinamento, EficaciaTreinamentoResponseDTO>().ReverseMap();
            CreateMap<EficaciaTreinamentoMetaRequestDTO, EficaciaTreinamentoMeta>().ReverseMap();
            CreateMap<EficaciaTreinamentoMeta, EficaciaTreinamentoMetaResponseDTO>().ReverseMap();

            CreateMap<DefeitoSoldagemRequestDTO, DefeitoSoldagem>().ReverseMap();
            CreateMap<DefeitoSoldagem, DefeitoSoldagemResponseDTO>()
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Localidade != null ? src.Localidade.Id : default))
                .ForMember(dest => dest.LocalidadeNome, opt => opt.MapFrom(src => src.Localidade != null ? src.Localidade.Nome : string.Empty))
                .ReverseMap();
            CreateMap<DefeitoSoldagemMetaRequestDTO, DefeitoSoldagemMeta>().ReverseMap();
            CreateMap<DefeitoSoldagemMeta, DefeitoSoldagemMetaResponseDTO>().ReverseMap();

            CreateMap<Usuario, UsuarioResponseDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioRequestDTO>().ReverseMap();

            CreateMap<Localidade, LocalidadeResponseDTO>().ReverseMap();
            CreateMap<Localidade, LocalidadeRequestDTO>().ReverseMap();

            CreateMap<LogCrud, LogCrudResponseDTO>()
                //.ForMember(dest => dest.LogTabelaNome, opt => opt.MapFrom(src => src.LogTabela.Nome))
                .ReverseMap();

        }
    }
}
