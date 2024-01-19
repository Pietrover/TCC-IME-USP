using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Assets.Scripts.OpenAIAPI
{
    //Classe que inicia o CLient da API do ChatGPT
    public class OpenAIAPIClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;


        //Inicia o objeto
        public OpenAIAPIClient()
        {
            _apiKey = "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";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.openai.com/v1/chat/completions");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        //Envia as prompts para a API e recebe a resposta
        public async Task<GPTMessage> SendPrompt(List<GPTMessage> promptLoad)
        {
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.temperature = 0.4;
            completionRequest.model = "gpt-3.5-turbo";
            completionRequest.messages = new List<GPTMessage>();
            completionRequest.messages.AddRange(promptLoad);
            completionRequest.max_tokens = 500;
            string requestString = JsonConvert.SerializeObject(completionRequest);
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", new StringContent(requestString, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var jsonResponse = JObject.Parse(responseBody);
            GPTMessage answer = new GPTMessage
            {
                content = (string)jsonResponse["choices"][0]["message"]["content"],
                role = (string)jsonResponse["choices"][0]["message"]["role"]
            };
            return answer;
        }
    }
}