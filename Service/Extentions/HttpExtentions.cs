using Microsoft.AspNetCore.Http;
using Service.Helpers;
using System.Text.Json;

namespace Service.Extentions
{
    public static class HttpExtentions
    {
        public static void AddPagenationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptions= new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("pagination", JsonSerializer.Serialize(header, jsonOptions));
            response.Headers.Add("Access-Control-Expose-Headers","pagination");

        }
    }
}
