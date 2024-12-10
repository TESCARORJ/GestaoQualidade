using Nuclep.GestaoQualidade.BlazorServer.Models.Interface;
using Nuclep.GestaoQualidade.Domain.Enumeradores;


namespace Nuclep.GestaoQualidade.BlazorServer.Models.Editar
{
    public class EditarTempoReparoEquipamentosProgramadosObrasMetaModel : IBaseModel
    {
        public int Meta { get; set; }
        public EnumAno Ano { get; set; }

    }
}
