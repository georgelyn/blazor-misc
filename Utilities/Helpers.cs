using System.Text.Json;

namespace Misc.Utilities
{
    public static class Helpers
    {
        private static readonly string[] _dataTypes = ["double", "decimal", "int", "float", "string", "bool", "datetime"];
        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public static string GetMappedDataType(string type)
        {
            var isNullable = type.Contains("?");
            var cleanString = type.Replace("?", string.Empty);
            switch (cleanString.ToLower())
            {
                case "double":
                case "decimal":
                case "float":
                case "int":
                case "long":
                    return $"number{(isNullable ? "?" : string.Empty)}";
                case "datetime":
                    return $"date{(isNullable ? "?" : string.Empty)}";
                default:
                    return type;
            }
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
    }
}