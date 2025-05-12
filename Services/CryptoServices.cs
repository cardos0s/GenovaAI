using System.Text.Json;

namespace GenovaAI.Services;

public class CryptoServices
{
    private readonly HttpClient _httpClient = new();

    public async Task<Dictionary<string, decimal>> GetCryptoPricesAsync()
    {
        var moedas = new[] { "bitcoin", "ethereum", "solana", "ripple" };
        var ids = string.Join(",", moedas);
        var url = $"https://api.coingecko.com/api/v3/simple/price?ids={ids}&vs_currencies=brl";
        
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine("JSON recebido: " + json);
            
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            var cotacoes = new Dictionary<string, decimal>();
                
            foreach (var moeda in moedas)
            {
                try
                {
                    var preco = root.GetProperty(moeda).GetProperty("brl").GetDecimal();
                    cotacoes[moeda.ToUpper()] = preco; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao ler valor de {moeda}: {ex.Message}");
                }
            }

            return cotacoes;
        }
        return null; 
    }
}