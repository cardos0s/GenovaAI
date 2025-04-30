using System.Net.Http.Json;
using GenovaAI.Models;

namespace GenovaAI.Services;

public class CotacaoServices 
{
    public async Task<Cotacao> GetCotacaoDolarAsync()
    {
        
        try
        {
            using var client = new HttpClient();
            var response = await client.GetFromJsonAsync<Dictionary<string, Cotacao>>("https://economia.awesomeapi.com.br/json/last/USD-BRL");

            return response["USDBRL"];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar cotação: {ex.Message}");
            return null;
        }
    }
}
