using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models.Indicadores
{
    public class CapacitacaoAreaContratosMeta : IEntidade
    {
        
        //public virtual Usuario? UsuarioCadastro { get; set; }
        public string? Ano { get; set; }
        public string? Trimestre { get; set; }
        public int Meta { get; set; }

    }
}
