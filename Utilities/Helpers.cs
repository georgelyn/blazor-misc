namespace Misc.Utilities
{
    public static class Helpers
    {
       private static readonly string[] _dataTypes = ["double", "decimal", "int", "float", "string", "bool", "datetime"];

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
    }
}