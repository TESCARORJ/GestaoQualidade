using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Helpers
{
    public static class Utils
    {
        public static string RemoverPrefixo(string input, string prefixo)
        {
            if (input.StartsWith(prefixo))
            {
                return input.Substring(prefixo.Length);
            }

            return input;
        }


    }
}
