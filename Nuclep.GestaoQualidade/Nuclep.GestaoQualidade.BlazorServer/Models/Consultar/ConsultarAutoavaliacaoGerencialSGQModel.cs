using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarAutoavaliacaoGerencialSGQModel : IBaseModel
    {
        public List<AutoavaliacaoGerencialSGQResponseDTO>? AutoavaliacaoGerencialSGQList { get; set; }

        public EnumAno Ano { get; set; }
        public long? Realizado { get; set; }
        public int Meta { get; set; }
    }
}
