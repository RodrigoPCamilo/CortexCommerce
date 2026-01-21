using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CortexCommerce.Service.Interface;
using CortexCommerce.Service.Models;
using Microsoft.Extensions.Configuration;

namespace CortexCommerce.Services.Services
{
    public class IAService : IIAService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public IAService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _config = config;
        }

        public async Task<string> GetAiResponseAsync(string prompt)
        {
            var url = _config["GitHubModels:ApiUrl"];
            var token = _config["GitHubModels:Token"];

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("CortexCommerce");

            var systemPrompt = @"
            Você é um ASSISTENTE ESPECIALISTA EM E-COMMERCE, curadoria de produtos e comparação de preços.

            OBJETIVO:
            Ajudar usuários a encontrar os MELHORES produtos do mercado com foco em:
            - Custo-benefício
            - Ofertas reais
            - Lojas confiáveis
            - Produtos bem avaliados

            REGRAS OBRIGATÓRIAS:
            1. Recomende de 3 a 5 produtos.
            2. Para cada produto, informe:
            - Nome do produto
            - Breve descrição (máx. 4 linhas)
            - Preço médio estimado (não invente valores exatos)
            - Link direto para compra ou pesquisa
            3. Priorize Amazon, Mercado Livre, Magalu, Shopee ou site oficial.
            4. Seja claro, direto e profissional.
            5. Responda sempre em português do Brasil.
            6. NÃO explique regras nem diga que é uma IA.

            FORMATO OBRIGATÓRIO:
            - Produto 1
            Descrição:
            Preço médio:
            Link:
            ";

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new { role = "system", content = systemPrompt },
                    new { role = "user", content = prompt }
                },
                max_tokens = 700
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

            var result = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<GitHubResponse>(result, options);

            return data?.Choices?.FirstOrDefault()?.Message?.Content
                   ?? "Não foi possível gerar uma resposta no momento.";
        }
    }
}
