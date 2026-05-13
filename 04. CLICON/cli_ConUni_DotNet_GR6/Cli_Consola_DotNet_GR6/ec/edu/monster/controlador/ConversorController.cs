using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ec.edu.monster.modelo;

namespace ec.edu.monster.controlador
{
    public class ConversorController
    {
        private readonly HttpClient _httpClient;

        public ConversorController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // TEMPERATURA
        public async Task<double> CelsiusAFahrenheit(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/CelsiusAFahrenheit/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CelsiusAFahrenheit: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> FahrenheitACelsius(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/FahrenheitACelsius/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en FahrenheitACelsius: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> CelsiusAKelvin(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/CelsiusAKelvin/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CelsiusAKelvin: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> KelvinACelsius(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/KelvinACelsius/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en KelvinACelsius: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> FahrenheitAKelvin(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/FahrenheitAKelvin/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en FahrenheitAKelvin: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> KelvinAFahrenheit(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/KelvinAFahrenheit/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en KelvinAFahrenheit: {ex.Message}");
                return 0;
            }
        }

        // LONGITUD
        public async Task<double> KmAMetros(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/KmAMetros/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en KmAMetros: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> MetrosACm(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/MetrosACm/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en MetrosACm: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> PulgadasACm(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/PulgadasACm/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en PulgadasACm: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> PiesAMetros(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/PiesAMetros/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en PiesAMetros: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> MillasAKm(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/MillasAKm/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en MillasAKm: {ex.Message}");
                return 0;
            }
        }

        // MASA
        public async Task<double> KgAGramos(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/KgAGramos/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en KgAGramos: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> GramosAMg(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/GramosAMg/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en GramosAMg: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> LibrasAKg(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/LibrasAKg/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en LibrasAKg: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> OnzasAGramos(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/OnzasAGramos/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en OnzasAGramos: {ex.Message}");
                return 0;
            }
        }

        public async Task<double> ToneladasAKg(double valor)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<double>($"api/Conversor/ToneladasAKg/{valor}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ToneladasAKg: {ex.Message}");
                return 0;
            }
        }
    }
}
