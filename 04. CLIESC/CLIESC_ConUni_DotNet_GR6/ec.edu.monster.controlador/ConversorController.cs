using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CLIESC_ConUni_DotNet_GR6.ec.edu.monster.controlador
{
    public class ConversorController
    {
        private const string ApiBaseUrl = "http://localhost:8090/api/conversor";
        private readonly HttpClient _client;

        public ConversorController()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<string> ConvertirAsync(string operacion, string valor)
        {
            string endpoint = ObtenerEndpoint(operacion, valor);

            if (string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentException("Operación no válida.");
            }

            string url = $"{ApiBaseUrl}/{endpoint}";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception($"Error del servidor: {response.StatusCode}");
        }

        private string ObtenerEndpoint(string operacion, string valor)
        {
            switch (operacion)
            {
                // TEMPERATURA
                case "Celsius a Fahrenheit": return $"CelsiusAFahrenheit/{valor}";
                case "Fahrenheit a Celsius": return $"FahrenheitACelsius/{valor}";
                case "Celsius a Kelvin": return $"CelsiusAKelvin/{valor}";
                case "Kelvin a Celsius": return $"KelvinACelsius/{valor}";
                case "Fahrenheit a Kelvin": return $"FahrenheitAKelvin/{valor}";
                case "Kelvin a Fahrenheit": return $"KelvinAFahrenheit/{valor}";

                // LONGITUD
                case "Kilometros a Metros": return $"KmAMetros/{valor}";
                case "Metros a Centimetros": return $"MetrosACm/{valor}";
                case "Pulgadas a Centimetros": return $"PulgadasACm/{valor}";
                case "Pies a Metros": return $"PiesAMetros/{valor}";
                case "Millas a Kilometros": return $"MillasAKm/{valor}";

                // MASA
                case "Kilogramos a Gramos": return $"KgAGramos/{valor}";
                case "Gramos a Kilogramos": return $"GramosAMg/{valor}";
                case "Libras a Kilogramos": return $"LibrasAKg/{valor}";
                case "Onzas a Gramos": return $"OnzasAGramos/{valor}";

                default: return null;
            }
        }
    }
}
