using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Helpers
{
    public static class ActiveDirectoryHelper
    {
        public static UserPrincipal GetUserDetails(string username)
        {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, username);

                if (userPrincipal != null)
                {
                    // Aqui você pode acessar diferentes propriedades do usuário no AD
                    string displayName = userPrincipal.DisplayName;
                    string email = userPrincipal.EmailAddress;

                    // Adicione mais propriedades conforme necessário

                    return userPrincipal;
                }
                else
                {
                    // O usuário não foi encontrado no AD
                    return null;
                }
            }
        }
    }
}
