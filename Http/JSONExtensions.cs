using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MDrop.Http
{
    public static class JSONExtensions
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues=true,
        };

        public static async Task<T> ReadAsJSON<T>(this HttpResponseMessage response) where T : class, new()
        {
            var stream = await response.Content.ReadAsStreamAsync();
            var tmp = await response.Content.ReadAsStringAsync();
            try
            {
                return await JsonSerializer.DeserializeAsync<T>(stream, jsonSerializerOptions);
            }
            catch (JsonException ex)
            {
                return new T();
            }

        }
    }
}
