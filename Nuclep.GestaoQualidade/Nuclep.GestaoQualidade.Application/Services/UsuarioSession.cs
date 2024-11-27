using Microsoft.AspNetCore.Http;
using Nuclep.GestaoQualidade.Application.Helpers;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Application.Interfaces.Sistema;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class UsuarioSession : IUsuarioSession
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;




        public UsuarioSession(IUsuarioRepository usuarioRepository, IHttpContextAccessor httpContextAccessor)
        {
            _usuarioRepository = usuarioRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Usuario> GetUsuarioLogado()
        {
            Usuario usuario = new Usuario();


            //string login = string.IsNullOrEmpty(_httpContextAccessor.HttpContext.User.Identity.Name) ? string.Empty : Utils.RemoverPrefixo(_httpContextAccessor.HttpContext.User.Identity.Name, "NUCLEP\\");
            var login = string.IsNullOrEmpty(WindowsIdentity.GetCurrent().Name) ? string.Empty : Utils.RemoverPrefixo(WindowsIdentity.GetCurrent().Name, "NUCLEP\\");


            var userPrincipal = ActiveDirectoryHelper.GetUserDetails(login);

            usuario = string.IsNullOrEmpty(login) ? new Usuario() : await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (usuario == null)
            {
                // Verifique se o usuário é nulo ou Nome é nulo/branco
                // Faça o que for necessário para obter ou configurar o Nome
                if (usuario == null || string.IsNullOrEmpty(usuario.NomeAD))
                {
                    usuario = new Usuario();
                    // Configure outras propriedades, se necessário
                    usuario.NomeAD = login;
                    usuario.PerfilSistema = Enums.NaoInformado;
                    usuario.UsuarioCadastro = _usuarioRepository.GetByIdAsync(1).Result;
                }

                usuario.Nome = userPrincipal != null ? userPrincipal.GivenName : "";

                await _usuarioRepository.AddAsync(usuario);
            }


            return usuario;
            

        }
    }
}
