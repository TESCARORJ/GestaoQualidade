using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models
{
    public class LogTabela 
    {
        public long Id { get; set; }
        public string? Nome { get; set; }

        public string? Descricao { get; set; }


        public override string ToString()
        {
            return this.Descricao.ToUpper();
        }
    }
}
