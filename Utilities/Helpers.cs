using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misc.Utilities
{
    public static class Helpers
    {

        public static List<string> GetSimpleDataTypes()
        {
            var dataTypes = new string[] { "double", "decimal", "int", "float", "string", "bool", "datetime" };
            var response = new List<string>();
            foreach (var type in dataTypes)
            {
                response.Add(type);
                response.Add($"{type}?");
            }

            return response;
        }

        public static string GetMappedDataTypes(string dataType)
        {
            var isSimpleType = GetSimpleDataTypes().Any(d => dataType.Contains(d, StringComparison.OrdinalIgnoreCase));
            return isSimpleType ? dataType.ToLower() : dataType;
        }
    }
}