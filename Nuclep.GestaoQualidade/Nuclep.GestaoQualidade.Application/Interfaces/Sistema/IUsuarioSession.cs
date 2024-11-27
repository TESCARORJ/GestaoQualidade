using Nuclep.GestaoQualidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Sistema
{
    public interface IUsuarioSession
    {
        /// <summary>
        /// Obtém o usuário que está logado neste momento.
        /// </summary>
        /// <returns>Usuário logado.</returns>
        Task<Usuario> GetUsuarioLogado();
    }
}
