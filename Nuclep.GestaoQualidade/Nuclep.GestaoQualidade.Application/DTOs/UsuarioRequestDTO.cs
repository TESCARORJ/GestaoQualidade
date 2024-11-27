using Nuclep.GestaoQualidade.Domain.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.DTOs
{
    public class UsuarioRequestDTO
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public long UsuarioCadastroId { get; set; }
        public string? UsuarioCadastroName { get; set; }
        [JsonIgnore]
        public DateTime DataHoraCadastro { get; set; }
        public string? Nome { get; set; }
        public string? NomeAD { get; set; }
        public Enums PerfilSistema { get; set; }
        public bool IsConfirmacaoNaoInformado { get; set; }
        public bool IsLocalidadeAramar { get; set; }
        public bool IsLocalidadeItaguai { get; set; }
        public bool IsCondensador { get; set; }
        public bool IsVPR { get; set; }
        public bool IsNivelServicoAtendimento { get; set; }
        public bool IsAderenciaProgramacaoMensal { get; set; }
        public bool IsCumprimentoEtapasPACDentroPrazo { get; set; }
        public bool IsSatisfacaoUsuario { get; set; }
        public bool IsTempoMedioSolucao { get; set; }
        public bool IsItensCadastradosMais15Dias { get; set; }
        public bool IsDuracaoProcessoLicitacao { get; set; }
        public bool IsEventosAtraso { get; set; }
        public bool IsFaturamentoRealizado { get; set; }
        public bool IsTempoManutencaoCorretivaEquipamentoProgramado { get; set; }
        public bool IsAcaoCorrecaoAvaliadaEficaz { get; set; }
        public bool IsCumprimentoVerbaDestinadaPATMME { get; set; }
        public bool IsAcaoDentroPrazo { get; set; }
        public bool IsAutoavaliacaoGerencialSGQ { get; set; }
        public bool IsCapacitacaoAreaContratos { get; set; }
        public bool IsOcupacaoMaoObra { get; set; }
        public bool IsProdutividadeMaoObra { get; set; }
        public bool IsGestaoProcessosPessoasPrevistoPAT { get; set; }
        public bool IsRespostaAreasPrazoOriginal { get; set; }
        public bool IsRetrabalhoDocumentos { get; set; }
        public bool IsSatisfacaoClientesAreaResponsavel { get; set; }
        public bool IsReducaoRNC { get; set; }
        public bool IsTaxaConformidadeDocumentosQualidade { get; set; }
        public bool IsTempoMedioInspecaoRecebimentoMateriais { get; set; }
        public bool IsTempoReparoEquipamentosProgramadosObras { get; set; }
    }
}
