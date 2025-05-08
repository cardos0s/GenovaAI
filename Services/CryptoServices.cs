using System.Text.Json;

namespace GenovaAI.Services;

public class CryptoServices
{
    private readonly HttpClient _httpClient = new();

    public async Task<Dictionary<string, decimal>> GetCryptoPricesAsync()
    {
        var url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum&vs_currencies=brl";
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine("JSON recebido: " + json);
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var cotacoes = new Dictionary<string, decimal>
            {
                {"BTC", root.GetProperty("bitcoin").GetProperty("brl").GetDecimal()},
                {"ETH", root.GetProperty("ethereum").GetProperty("brl").GetDecimal()},

            };
            return cotacoes;
        }
        return null; 
    }
}