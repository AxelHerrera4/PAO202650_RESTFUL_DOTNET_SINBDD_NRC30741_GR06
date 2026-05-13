using System.Collections.Generic;

namespace ec.edu.monster.modelo
{
    public class ConversionModel
    {
        public static string GetEndpoint(string operacion, string valorStr)
        {
            switch (operacion)
            {
                // TEMPERATURA
                case "Celsius a Fahrenheit": return "CelsiusAFahrenheit/" + valorStr;
                case "Fahrenheit a Celsius": return "FahrenheitACelsius/" + valorStr;
                case "Celsius a Kelvin": return "CelsiusAKelvin/" + valorStr;
                case "Kelvin a Celsius": return "KelvinACelsius/" + valorStr;
                case "Fahrenheit a Kelvin": return "FahrenheitAKelvin/" + valorStr;
                case "Kelvin a Fahrenheit": return "KelvinAFahrenheit/" + valorStr;

                // LONGITUD
                case "Kilometros a Metros": return "KmAMetros/" + valorStr;
                case "Metros a Centimetros": return "MetrosACm/" + valorStr;
                case "Pulgadas a Centimetros": return "PulgadasACm/" + valorStr;
                case "Pies a Metros": return "PiesAMetros/" + valorStr;
                case "Millas a Kilometros": return "MillasAKm/" + valorStr;

                // MASA
                case "Kilogramos a Gramos": return "KgAGramos/" + valorStr;
                case "Gramos a Kilogramos": return "GramosAMg/" + valorStr;
                case "Libras a Kilogramos": return "LibrasAKg/" + valorStr;
                case "Onzas a Gramos": return "OnzasAGramos/" + valorStr;

                default: return null;
            }
        }

        public static List<string> ObetenerOperaciones(string categoria)
        {
            var operaciones = new List<string>();

            if (categoria == "LONGITUD")
            {
                operaciones.AddRange(new[]
                {
                    "Kilometros a Metros",
                    "Metros a Centimetros",
                    "Pulgadas a Centimetros",
                    "Pies a Metros",
                    "Millas a Kilometros"
                });
            }
            else if (categoria == "TEMPERATURA")
            {
                 operaciones.AddRange(new[]
                 {
                    "Celsius a Fahrenheit",
                    "Fahrenheit a Celsius",
                    "Celsius a Kelvin",
                    "Kelvin a Celsius",
                    "Fahrenheit a Kelvin",
                    "Kelvin a Fahrenheit"
                 });
            }
            else if (categoria == "MASA")
            {
                operaciones.AddRange(new[]
                {
                    "Kilogramos a Gramos",
                    "Gramos a Kilogramos",
                    "Libras a Kilogramos",
                    "Onzas a Gramos"
                });
            }

            return operaciones;
        }

        public static string ObtenerPlaceholder(string categoria)
        {
            if (categoria == "LONGITUD") return "Ingresa unidades de longitud";
            if (categoria == "TEMPERATURA") return "Ingresa grados";
            if (categoria == "MASA") return "Ingresa unidades de masa";
            return "Ingresa un valor";
        }
    }
}
