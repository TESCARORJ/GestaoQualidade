using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class RetrabalhoDocumentos : IEntidade
    {


        public string? Ano { get; set; }
        public string? Mes { get; set; }
        public decimal DevRev { get; set; }
        public decimal DevTotal { get; set; }

        public List<RetrabalhoDocumentosMeta> MesList;
       
    }
}
