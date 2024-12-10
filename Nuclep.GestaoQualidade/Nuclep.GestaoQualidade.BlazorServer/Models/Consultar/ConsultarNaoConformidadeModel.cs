using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarNaoConformidadeModel : IBaseModel
    {
        public List<NaoConformidadeResponseDTO>? NaoConformidadeList { get; set; }
        public EnumAno Ano { get; set; }
        public EnumMes Mes { get; set; }
        public long? Atividade1 { get; set; }
        public long? Atividade2 { get; set; }
        public int Meta { get; set; }
    }
}
