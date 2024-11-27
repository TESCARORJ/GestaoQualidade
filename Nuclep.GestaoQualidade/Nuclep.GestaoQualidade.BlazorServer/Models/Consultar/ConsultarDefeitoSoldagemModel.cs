using Nuclep.GestaoQualidade.BlazorServer.DTOs;
using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.BlazorServer.Models.Consultar
{
    public class ConsultarDefeitoSoldagemModel : IBaseModel
    {
        public List<DefeitoSoldagemResponseDTO>? DefeitoSoldagemList { get; set; }

        public EnumMes Mes { get; set; }
        public EnumAno Ano { get; set; }
        public Localidade? Localidade { get; set; }
        public long? TotalAtividadesProgramadas { get; set; }
        public long? AtividadesRealizadas { get; set; }
        public long? AtividadesCanceladas { get; set; }
        public int Meta { get; set; }
    }
}
