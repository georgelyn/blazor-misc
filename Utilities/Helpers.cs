using System.Text.Json;
using System.Text.RegularExpressions;

namespace Misc.Utilities
{
    public static class Helpers
    {
        private static readonly string[] _dataTypes = ["double", "decimal", "int", "float", "string", "bool", "datetime"];
        private static readonly HashSet<string> _listTypes = ["ienumerable", "icollection", "list"];

        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public static string GetMappedDataType(string type)
        {
            bool isListType = _listTypes.Any(t => type.StartsWith(t, StringComparison.OrdinalIgnoreCase)
                || type.Contains("[]"));
            if (isListType)
            {
                var isNullable = type.Contains("?");
                type = type.Replace("?", string.Empty);
                var match = Regex.Match(type, @"^(?:[\w\.]+<([\w\.]+)>|([\w\.]+)\[\])$");
                if (!match.Success)
                    return type;
                
                var dataType = match.Groups[1].Value;
                if (string.IsNullOrEmpty(dataType))
                    dataType = match.Groups[2].Value;
                var mappedType = GetSimpleTypeMapping(dataType);

                return $"{mappedType}[]{(isNullable ? "?" : string.Empty)}";
            }

            return GetSimpleTypeMapping(type);
        }

        public static (string? Json, Exception? ex) FormatJson(string json)
        {
            try
            {
                using var doc = JsonDocument.Parse(json);
                return (JsonSerializer.Serialize(doc, _serializerOptions), null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }

        private static string GetSimpleTypeMapping(string type)
        {
            var isNullable = type.Contains("?");
            var cleanString = type.Replace("?", string.Empty);
            switch (cleanString.ToLower())
            {
                case "double":
                case "decimal":
                case "float":
                case "int":
                case "uint":
                case "long":
                    return $"number{(isNullable ? "?" : string.Empty)}";
                case "datetime":
                case "datetimeoffset":
                    return $"date{(isNullable ? "?" : string.Empty)}";
                default:
                    return type;
            }
        }
    }
}