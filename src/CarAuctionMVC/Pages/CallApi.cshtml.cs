using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;

namespace CarAuctionMVC.Pages
{
    public class CallApiModel(IHttpClientFactory httpClientFactory) : PageModel
    {
        public async Task OnGet()
        {

            var client = httpClientFactory.CreateClient("apiClient");
            var content = await client.GetStringAsync("https://localhost:2000/api/v1/auction");

            var parsed = JsonDocument.Parse(content);
            var formated = JsonSerializer.Serialize(content, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
