﻿using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Cadastrar
{
    public class CadastrarTempoMedioSolucaoMetaModel : IBaseModel
    {
        public EnumAno Ano { get; set; }
        public int Meta { get; set; }
    }
}