using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Helpers
{
    public static class ViewModelHelper
    {
        public static Dictionary<string, Tuple<dynamic, dynamic>> PublicInstancePropertiesEqual<T>(T self, T to, params string[] ignore) where T : class
        {
            var differences = new Dictionary<string, Tuple<dynamic, dynamic>>();

            if (self != null && to != null)
            {
                var type = typeof(T);
                var ignoreList = new List<string>(ignore);
                foreach (
                    System.Reflection.PropertyInfo pi in
                        type.GetProperties(System.Reflection.BindingFlags.Public |
                                           System.Reflection.BindingFlags.Instance))
                {
                    if (ignoreList.Contains(pi.Name)) continue;

                    var selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                    var toValue = type.GetProperty(pi.Name).GetValue(to, null);

                    if (selfValue == null || string.IsNullOrEmpty(selfValue.ToString()))
                        selfValue = "Sem Dado";

                    if (toValue == null || string.IsNullOrEmpty(toValue.ToString()))
                        toValue = "Sem Dado";

                    if (selfValue is IEnumerable<object>)
                    {
                        if (string.Join(",", ((IEnumerable<object>)selfValue).Select(x => x.ToString()))
                            == string.Join(",", ((IEnumerable<object>)toValue).Select(x => x.ToString())))
                            continue;

                        var nomeAtributo = pi.GetCustomAttributes(typeof(DescriptionAttribute), true).Any()
                            ? ((DescriptionAttribute)
                                pi.GetCustomAttributes(typeof(DescriptionAttribute), true)[0]).Description
                            : pi.Name;


                        differences.Add(
                            nomeAtributo,
                            new Tuple<dynamic, dynamic>(
                                selfValue,
                                string.Join(",", ((IEnumerable<object>)toValue).Select(x => x.ToString()))));
                    }
                    else
                    {
                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            var nomeAtributo = pi.GetCustomAttributes(typeof(DescriptionAttribute), true).Any()
                                ? ((DescriptionAttribute)
                                    pi.GetCustomAttributes(typeof(DescriptionAttribute), true)[0]).Description
                                : pi.Name;

                            if (selfValue is bool)
                            {
                                differences.Add(nomeAtributo, new Tuple<dynamic, dynamic>((bool)selfValue ? "Sim" : "Não", toValue == "Sem Dado" ? toValue : (bool)toValue ? "Sim" : "Não"));
                            }
                            else
                            {
                                differences.Add(nomeAtributo, new Tuple<dynamic, dynamic>(selfValue, toValue));
                            }


                        }
                    }
                }
            }

            return differences;
        }
    }

}
