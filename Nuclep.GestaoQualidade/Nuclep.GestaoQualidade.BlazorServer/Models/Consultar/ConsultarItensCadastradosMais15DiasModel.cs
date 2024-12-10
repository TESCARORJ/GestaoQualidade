using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarItensCadastradosMais15DiasModel : IBaseModel
    {
        public List<ItensCadastradosMais15DiasResponseDTO>? ItensCadastradosMais15DiasList { get; set; }
        public EnumAno Ano { get; set; }
        public EnumMes Mes { get; set; }
        public long? QuantidadeItensCadastrados15Dias { get; set; }
        public long? QuantidadeItensCadastrados { get; set; }
        public int Meta { get; set; }
    }
}
