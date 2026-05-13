using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ec.edu.monster.controlador
{
    public class ConversionController
    {
        private const string ApiBaseUrl = "http://localhost:8090/api/conversor";
        private readonly HttpClient _httpClient;

        public ConversionController()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<double> ConvertirAsync(string endpoint)
        {
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentException("El endpoint no puede ser nulo o vacío.");
            }

            string url = $"{ApiBaseUrl}/{endpoint}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string resultadoStr = await response.Content.ReadAsStringAsync();
                return double.Parse(resultadoStr);
            }
            else
            {
                throw new Exception($"Error del servidor: {response.StatusCode}");
            }
        }
    }
}
