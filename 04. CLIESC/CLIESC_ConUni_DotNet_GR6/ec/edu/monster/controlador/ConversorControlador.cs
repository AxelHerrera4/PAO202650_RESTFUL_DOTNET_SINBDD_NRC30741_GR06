using System;
using System.Net.Http;
using System.Threading.Tasks;
using ec.edu.monster.modelo;

namespace ec.edu.monster.controlador
{
    public class ConversorControlador
    {
        // URL base de tu API REST
        private const string ApiBaseUrl = "http://localhost:8090/api/conversor";

        public ConversorControlador()
        {
        }

        /// <summary>
        /// Realiza la conversión llamando al Web Service REST
        /// </summary>
        public async Task<ConversorOperacion> ConvertirAsync(ConversorOperacion operacion)
        {
            try
            {
                if (operacion == null || operacion.Valor == 0)
                {
                    operacion.Mensaje = "Valores inválidos";
                    return operacion;
                }

                string endpoint = ObtenerEndpoint(operacion.Operacion, operacion.Valor);

                if (string.IsNullOrEmpty(endpoint))
                {
                    operacion.Mensaje = "Operación no válida";
                    return operacion;
                }

                string url = $"{ApiBaseUrl}/{endpoint}";

                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string resultadoStr = await response.Content.ReadAsStringAsync();
                        operacion.Resultado = double.Parse(resultadoStr);
                        operacion.Mensaje = "Éxito";
                    }
                    else
                    {
                        operacion.Mensaje = $"Error del servidor: {response.StatusCode}";
                    }
                }
            }
            catch (Exception ex)
            {
                operacion.Mensaje = $"Error: {ex.Message}";
            }

            return operacion;
        }

        /// <summary>
        /// Mapea la operación al endpoint REST correcto
        /// </summary>
        private string ObtenerEndpoint(string operacion, double valor)
        {
            switch (operacion)
            {
                // TEMPERATURA
                case "Celsius a Fahrenheit": return "CelsiusAFahrenheit/" + valor;
                case "Fahrenheit a Celsius": return "FahrenheitACelsius/" + valor;
                case "Celsius a Kelvin": return "CelsiusAKelvin/" + valor;
                case "Kelvin a Celsius": return "KelvinACelsius/" + valor;
                case "Fahrenheit a Kelvin": return "FahrenheitAKelvin/" + valor;
                case "Kelvin a Fahrenheit": return "KelvinAFahrenheit/" + valor;

                // LONGITUD
                case "Kilometros a Metros": return "KmAMetros/" + valor;
                case "Metros a Centimetros": return "MetrosACm/" + valor;
                case "Pulgadas a Centimetros": return "PulgadasACm/" + valor;
                case "Pies a Metros": return "PiesAMetros/" + valor;
                case "Millas a Kilometros": return "MillasAKm/" + valor;

                // MASA
                case "Kilogramos a Gramos": return "KgAGramos/" + valor;
                case "Gramos a Kilogramos": return "GramosAMg/" + valor;
                case "Libras a Kilogramos": return "LibrasAKg/" + valor;
                case "Onzas a Gramos": return "OnzasAGramos/" + valor;

                default: return null;
            }
        }

        /// <summary>
        /// Valida las credenciales del usuario
        /// </summary>
        public bool ValidarLogin(UsuarioLogin usuario)
        {
            if (usuario == null)
                return false;

            return usuario.Usuario == "monster" && usuario.Contrasena == "monster9";
        }
    }
}
