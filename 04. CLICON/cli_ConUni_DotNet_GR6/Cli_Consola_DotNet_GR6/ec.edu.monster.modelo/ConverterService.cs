using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ec.edu.monster.modelo
{
    public class ConverterService : IDisposable
    {
        private readonly HttpClient _client;

        public ConverterService(string baseAddress)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        public async Task<double> ConvertirTemperaturaAsync(string subOpcion, double val)
        {
            return subOpcion switch
            {
                "1" => await _client.GetFromJsonAsync<double>($"api/Conversor/CelsiusAFahrenheit/{val}"),
                "2" => await _client.GetFromJsonAsync<double>($"api/Conversor/FahrenheitACelsius/{val}"),
                "3" => await _client.GetFromJsonAsync<double>($"api/Conversor/CelsiusAKelvin/{val}"),
                "4" => await _client.GetFromJsonAsync<double>($"api/Conversor/KelvinACelsius/{val}"),
                "5" => await _client.GetFromJsonAsync<double>($"api/Conversor/FahrenheitAKelvin/{val}"),
                "6" => await _client.GetFromJsonAsync<double>($"api/Conversor/KelvinAFahrenheit/{val}"),
                _ => 0
            };
        }

        public async Task<double> ConvertirLongitudAsync(string subOpcion, double val)
        {
            return subOpcion switch
            {
                "1" => await _client.GetFromJsonAsync<double>($"api/Conversor/KmAMetros/{val}"),
                "2" => await _client.GetFromJsonAsync<double>($"api/Conversor/MetrosACm/{val}"),
                "3" => await _client.GetFromJsonAsync<double>($"api/Conversor/PulgadasACm/{val}"),
                "4" => await _client.GetFromJsonAsync<double>($"api/Conversor/PiesAMetros/{val}"),
                "5" => await _client.GetFromJsonAsync<double>($"api/Conversor/MillasAKm/{val}"),
                _ => 0
            };
        }

        public async Task<double> ConvertirMasaAsync(string subOpcion, double val)
        {
            return subOpcion switch
            {
                "1" => await _client.GetFromJsonAsync<double>($"api/Conversor/KgAGramos/{val}"),
                "2" => await _client.GetFromJsonAsync<double>($"api/Conversor/GramosAMg/{val}"),
                "3" => await _client.GetFromJsonAsync<double>($"api/Conversor/LibrasAKg/{val}"),
                "4" => await _client.GetFromJsonAsync<double>($"api/Conversor/OnzasAGramos/{val}"),
                "5" => await _client.GetFromJsonAsync<double>($"api/Conversor/ToneladasAKg/{val}"),
                _ => 0
            };
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}