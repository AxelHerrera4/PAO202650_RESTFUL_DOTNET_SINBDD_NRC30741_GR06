using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

// 1. Configuración inicial y Login con Reintentos
while (true)
{
    Console.Clear();
    Console.WriteLine("====================================");
    Console.WriteLine("   CLIENTE C# - CONVERSOR ESPE      ");
    Console.WriteLine("====================================");

    Console.Write("Usuario: ");
    string user = Console.ReadLine();
    Console.Write("Contraseña: ");
    string pass = Console.ReadLine();

    if (user == "monster" && pass == "monster9")
    {
        Console.WriteLine("\n[+] Acceso concedido.\n");
        System.Threading.Thread.Sleep(1000);
        break;
    }
    else
    {
        Console.WriteLine("\n[!] Credenciales incorrectas. Intente de nuevo.");
        Console.WriteLine("Presione cualquier tecla para reintentar...");
        Console.ReadKey();
    }
}

// 2. Instanciar el cliente HTTP
using var client = new HttpClient();
client.BaseAddress = new Uri("http://localhost:8090/");

try
{
    bool continuar = true;
    while (continuar)
    {
        Console.Clear();
        Console.WriteLine("=== MENÚ PRINCIPAL ===");
        Console.WriteLine("1. Conversiones de Temperatura");
        Console.WriteLine("2. Conversiones de Longitud");
        Console.WriteLine("3. Conversiones de Masa");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");

        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                await MenuTemperatura(client);
                break;
            case "2":
                await MenuLongitud(client);
                break;
            case "3":
                await MenuMasa(client);
                break;
            case "4":
                continuar = false;
                break;
            default:
                Console.WriteLine("Opción no válida.");
                System.Threading.Thread.Sleep(1000);
                break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"\n[!] Error de comunicación: {ex.Message}");
    Console.ReadKey();
}

Console.WriteLine("\nGracias por usar ConUni. Presione cualquier tecla para cerrar.");
Console.ReadKey();

// --- MÉTODOS DE MENÚ CON NOMBRES COMPLETOS ---

async Task MenuTemperatura(HttpClient client)
{
    Console.WriteLine("\n-- TEMPERATURA --");
    Console.WriteLine("1. Celsius a Fahrenheit");
    Console.WriteLine("2. Fahrenheit a Celsius");
    Console.WriteLine("3. Celsius a Kelvin");
    Console.WriteLine("4. Kelvin a Celsius");
    Console.WriteLine("5. Fahrenheit a Kelvin");
    Console.WriteLine("6. Kelvin a Fahrenheit");
    Console.Write("Seleccione: ");
    string subOp = Console.ReadLine();

    Console.Write("Ingrese valor: ");
    if (double.TryParse(Console.ReadLine(), out double val))
    {
        double res = subOp switch
        {
            "1" => await client.GetFromJsonAsync<double>($"api/Conversor/CelsiusAFahrenheit/{val}"),
            "2" => await client.GetFromJsonAsync<double>($"api/Conversor/FahrenheitACelsius/{val}"),
            "3" => await client.GetFromJsonAsync<double>($"api/Conversor/CelsiusAKelvin/{val}"),
            "4" => await client.GetFromJsonAsync<double>($"api/Conversor/KelvinACelsius/{val}"),
            "5" => await client.GetFromJsonAsync<double>($"api/Conversor/FahrenheitAKelvin/{val}"),
            "6" => await client.GetFromJsonAsync<double>($"api/Conversor/KelvinAFahrenheit/{val}"),
            _ => 0
        };
        Console.WriteLine($">> Resultado: {res:N2}");
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
}

async Task MenuLongitud(HttpClient client)
{
    Console.WriteLine("\n-- LONGITUD --");
    Console.WriteLine("1. Kilómetros a Metros");
    Console.WriteLine("2. Metros a Centímetros");
    Console.WriteLine("3. Pulgadas a Centímetros");
    Console.WriteLine("4. Pies a Metros");
    Console.WriteLine("5. Millas a Kilómetros");
    Console.Write("Seleccione: ");
    string subOp = Console.ReadLine();

    Console.Write("Ingrese valor: ");
    if (double.TryParse(Console.ReadLine(), out double val))
    {
        double res = subOp switch
        {
            "1" => await client.GetFromJsonAsync<double>($"api/Conversor/KmAMetros/{val}"),
            "2" => await client.GetFromJsonAsync<double>($"api/Conversor/MetrosACm/{val}"),
            "3" => await client.GetFromJsonAsync<double>($"api/Conversor/PulgadasACm/{val}"),
            "4" => await client.GetFromJsonAsync<double>($"api/Conversor/PiesAMetros/{val}"),
            "5" => await client.GetFromJsonAsync<double>($"api/Conversor/MillasAKm/{val}"),
            _ => 0
        };
        Console.WriteLine($">> Resultado: {res:N2}");
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
}

async Task MenuMasa(HttpClient client)
{
    Console.WriteLine("\n-- MASA --");
    Console.WriteLine("1. Kilogramos a Gramos");
    Console.WriteLine("2. Gramos a Miligramos");
    Console.WriteLine("3. Libras a Kilogramos");
    Console.WriteLine("4. Onzas a Gramos");
    Console.WriteLine("5. Toneladas a Kilogramos");
    Console.Write("Seleccione: ");
    string subOp = Console.ReadLine();

    Console.Write("Ingrese valor: ");
    if (double.TryParse(Console.ReadLine(), out double val))
    {
        double res = subOp switch
        {
            "1" => await client.GetFromJsonAsync<double>($"api/Conversor/KgAGramos/{val}"),
            "2" => await client.GetFromJsonAsync<double>($"api/Conversor/GramosAMg/{val}"),
            "3" => await client.GetFromJsonAsync<double>($"api/Conversor/LibrasAKg/{val}"),
            "4" => await client.GetFromJsonAsync<double>($"api/Conversor/OnzasAGramos/{val}"),
            "5" => await client.GetFromJsonAsync<double>($"api/Conversor/ToneladasAKg/{val}"),
            _ => 0
        };
        Console.WriteLine($">> Resultado: {res:N2}");
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
}