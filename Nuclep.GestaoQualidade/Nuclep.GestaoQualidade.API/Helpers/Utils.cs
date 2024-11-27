namespace Nuclep.GestaoQualidade.API.Helpers
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
