﻿using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class SatisfacaoClientesAreaResponsavelMeta : IEntidade
    {
        public string? Ano { get; set; }
        public int Meta { get; set; }

    }
}
