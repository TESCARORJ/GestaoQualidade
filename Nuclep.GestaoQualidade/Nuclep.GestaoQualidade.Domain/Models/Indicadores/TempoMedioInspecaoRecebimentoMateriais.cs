﻿using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class TempoMedioInspecaoRecebimentoMateriais : IEntidade
    {
        public string? Ano { get; set; }
        public string? Mes { get; set; }
        public decimal Realizado { get; set; }

        public List<TempoMedioInspecaoRecebimentoMateriaisMeta> MesList;
       
    }
}
