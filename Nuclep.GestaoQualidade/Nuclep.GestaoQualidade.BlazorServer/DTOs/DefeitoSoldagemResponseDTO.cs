﻿using Nuclep.GestaoQualidade.BlazorServer.DTOs.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.BlazorServer.DTOs
{
    public class DefeitoSoldagemResponseDTO
    {
        public long Id { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public long UsuarioCadastroId { get; set; }
        public long LocalidadeId { get; set; }
        public string? LocalidadeNome { get; set; }
        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public long? TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos { get; set; }
        public long? TotalComprimentoSoldadoInspecionado { get; set; }
        public int Meta { get; set; }

    }
}