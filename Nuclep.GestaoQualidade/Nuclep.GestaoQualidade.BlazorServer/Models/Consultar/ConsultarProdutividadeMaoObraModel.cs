using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarProdutividadeMaoObraModel : IBaseModel
    {
        public List<ProdutividadeMaoObraResponseDTO>? ProdutividadeMaoObraList { get; set; }
        public EnumAno Ano { get; set; }
        public EnumMes Mes { get; set; }
        public long? TempoTotalFaturavel { get; set; }
        public long? TempoDisponivelTotal { get; set; }
        public int Meta { get; set; }
    }
}
