using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using CortexCommerce.Service.Interface;

namespace CortexCommerce.Service.Services
{
    
  public class AiService : IIAService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public AiService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<string> GetAiResponseAsync(string prompt)
        {
            var url = "https://models.inference.ai.azure.com/chat/completions";
            var token = _config["GitHubModels:Token"];

            if (string.IsNullOrWhiteSpace(token))
                throw new Exception("Token do GitHub Models não configurado.");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);


            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("CortexCommerce");

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content = @"
Você é um ASSISTENTE ESPECIALISTA EM E-COMMERCE, curadoria de produtos e comparação de preços.

OBJETIVO:
Ajudar usuários a encontrar os MELHORES produtos do mercado com foco em custo-benefício.

REGRAS:
- Recomende de 3 a 5 produtos
- Informe nome, descrição curta, preço médio e link
- Priorize Amazon, Mercado Livre, Magalu, Shopee
- Responda em português do Brasil
- NÃO diga que é uma IA
"
                    },
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                },
                max_tokens = 500
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro IA: {response.StatusCode} - {error}");
            }

            var json = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(json);
            return doc
                .RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString()
                ?? "Sem resposta da IA.";
        }
    }
}
