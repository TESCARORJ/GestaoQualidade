using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models.Sistema;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class QuestionarioHomologacaoMap:ClassMap<QuestionarioHomologacao>
    {
        public QuestionarioHomologacaoMap()
        {
            Table("QuestionarioHomologacao");

            Id(x => x.Id);

            Map(x => x.IsAtivo);
            Map(x => x.DataHoraCadastro);
            Map(x => x.IsFormularioCriadoCorretamente);
            Map(x => x.DescricaoAlteracaoFormulario);
            Map(x => x.IsAdicionarEditarCampo);
            Map(x => x.DescricaoAdicionarEditarCampo);
            Map(x => x.IsRegraNegocio);
            Map(x => x.DescricaoRegraNegocio);
            Map(x => x.IsListaCriadoCorretamente);
            Map(x => x.DescricaoAlteracaoLista);
            Map(x => x.IsDetalheCriadoCorretamente);
            Map(x => x.DescricaoAlteracaoDetalhe);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");
            References(x => x.Formulario).Column("IdFormulario");
        }
    }
}
