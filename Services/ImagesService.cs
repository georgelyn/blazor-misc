using System.Net.Http.Json;
using System.Web;
using Misc.Shared.Models;

namespace Misc.Services
{
    public interface IImagesService
    {
        Task<PixabayObject?> GetImagesByKeywordAsync(string keyword, int page, int pageSize, string language);
    }

    public class ImagesService : IImagesService
    {
        private readonly HttpClient _client;
        private readonly string _key = "52547938-52acda17a80f582bb01c56e28";

        public ImagesService(HttpClient http)
        {
            _client = http;
        }

        public async Task<PixabayObject?> GetImagesByKeywordAsync(string keyword, int page, int pageSize, string language)
        {
            try
            {
                var requestParams = GetParamsWithValue(GetParams(keyword: keyword, pageNumber: page, pageSize: pageSize, language: language));
                var parameters = string.Join("&", requestParams.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));

                var images = await _client.GetFromJsonAsync<PixabayObject>($"?{parameters}");
                return images;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Dictionary<string, string> GetParams(string? keyword = "", int? id = null, int? pageNumber = null, int? pageSize = null,
                                                string? type = "photo", string? orientation = "all", string? language = "en")
        {
            return new Dictionary<string, string>()
            {
                {"key", _key},
                {"q", keyword?.Replace(" ", "+") ?? ""},
                {"id", id.ToString() ?? ""},
                {"page", pageNumber.ToString() ?? "1"},
                {"per_page", pageSize.ToString() ?? ""},
                {"image_type", type ?? ""},
                {"orienation", orientation ?? ""},
                {"lang", language ?? ""},
            };
        }

        private Dictionary<string, string> GetParamsWithValue(Dictionary<string, string> dict)
        {
            var paramsWithValues = new Dictionary<string, string>();
            foreach (var parameter in dict)
            {
                if (!string.IsNullOrWhiteSpace(parameter.Value) && !paramsWithValues.ContainsKey(parameter.Key))
                    paramsWithValues.Add(parameter.Key, parameter.Value);
            }

            return paramsWithValues;
        }
    }
}