using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Model;

namespace Nuclep.GestaoQualidade.Domain.Models
{
    public class LogCrud : IEntidade
    {
        public LogCrud() { }

        public LogCrud(Usuario usuario, LogTipo tipo, LogTabela tabela, string nomeFormulario, string de, string para/*, Residuo residuo*/)
        {
            DataHoraCadastro = DateTime.Now;
            Usuario = usuario;
            LogTipo = tipo;
            LogTabela = tabela;
            //Residuo = residuo;

            if (tipo == LogTipo.Cadastrado)
            {
                Descricao = string.Format("Cadastrado por {0} em {1}", usuario.Nome, DateTime.Now);
            }
            else if (tipo == LogTipo.Excluido)
            {
                Descricao = string.Format("Excluído por {0} em {1}", usuario.Nome, DateTime.Now);
            }
            else
            {
                Descricao = string.Format("{0} atualizado(a) de '{1}' para '{2}' pelo usuário(a) {3} em {4}", nomeFormulario, de, para, usuario.Nome, DateTime.Now); 
            }
        }


        public LogCrud(Usuario usuario, LogTipo tipo, LogTabela tabela, string nomeFormulario, string de, string para, long idRef/*, Residuo residuo*/)
        {
            DataHoraCadastro = DateTime.Now;
            Usuario = usuario;
            LogTipo = tipo;
            LogTabela = tabela;
            IdReferencia = idRef;
            //Residuo = residuo;

            if (tipo == LogTipo.Cadastrado)
            {
                Descricao = string.Format("Cadastrado por {0} em {1}", usuario.Nome, DateTime.Now);
            }
            else if (tipo == LogTipo.Excluido)
            {
                Descricao = string.Format("Excluído por {0} em {1}", usuario.Nome, DateTime.Now);
            }
            else
            {
                Descricao = string.Format("{0} atualizado(a) de '{1}' para '{2}' pelo usuário(a) {3} em {4}", nomeFormulario, de, para, usuario.Nome, DateTime.Now);
            }
        }

        public LogCrud(Usuario usuario, LogTipo tipo, LogTabela tabela)
        {
            DataHoraCadastro = DateTime.Now;
            Usuario = usuario;
            LogTipo = tipo;
            LogTabela = tabela;

            if (tipo == LogTipo.Cadastrado)
            {
                Descricao = string.Format("Cadastrado por {0} em {1}", usuario.Nome, DateTime.Now);
            }
            else if (tipo == LogTipo.Excluido)
            {
                Descricao = string.Format("Excluído por {0} em {1}", usuario.Nome, DateTime.Now);
            }
            else
            {
                Descricao = string.Format("Posições das Widgets alteradas por: {0} em {1}", usuario.Nome, DateTime.Now);
            }
        }

        public long Id { get; set; }
        public long IdReferencia { get; set; }
        public LogTipo LogTipo { get; set; }
        public long LogTabelaId { get; set; }
        public LogTabela LogTabela { get; set; }
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string Descricao { get; set; }


    }
}
