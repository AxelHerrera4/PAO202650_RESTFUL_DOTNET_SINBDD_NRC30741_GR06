using System;
using System.Net.Http;
using System.Threading.Tasks;
using ec.edu.monster.controlador;
using ec.edu.monster.vista;

// 1. Configuración inicial - Cliente HTTP
using var httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("http://10.40.26.222:8090/");

// 2. Instanciar View y Controller
var view = new ConsoleView();
var controller = new ConversorController(httpClient);

// 3. Login
while (true)
{
    view.MostrarLoginUI();
    string user = Console.ReadLine();
    view.MostrarPedidoPassword();
    string pass = Console.ReadLine();

    if (user == "monster" && pass == "monster9")
    {
        view.MostrarAccesoConcedido();
        break;
    }
    else
    {
        view.MostrarAccesoDenegado();
    }
}

// 4. Menú Principal
try
{
    bool continuar = true;
    while (continuar)
    {
        view.MostrarMenuPrincipal();
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                await MenuTemperatura(controller, view);
                break;
            case "2":
                await MenuLongitud(controller, view);
                break;
            case "3":
                await MenuMasa(controller, view);
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

// --- MÉTODOS DE MENÚ ---

async Task MenuTemperatura(ConversorController controller, ConsoleView view)
{
    view.MostrarMenuTemperatura();
    string subOp = Console.ReadLine();
    view.MostrarPedidoValor();

    if (double.TryParse(Console.ReadLine(), out double val))
    {
        double res = subOp switch
        {
            "1" => await controller.CelsiusAFahrenheit(val),
            "2" => await controller.FahrenheitACelsius(val),
            "3" => await controller.CelsiusAKelvin(val),
            "4" => await controller.KelvinACelsius(val),
            "5" => await controller.FahrenheitAKelvin(val),
            "6" => await controller.KelvinAFahrenheit(val),
            _ => 0
        };
        view.MostrarResultado(res);
    }
    else
    {
        view.MostrarError("Valor inválido");
    }
}

async Task MenuLongitud(ConversorController controller, ConsoleView view)
{
    view.MostrarMenuLongitud();
    string subOp = Console.ReadLine();
    view.MostrarPedidoValor();

    if (double.TryParse(Console.ReadLine(), out double val))
    {
        double res = subOp switch
        {
            "1" => await controller.KmAMetros(val),
            "2" => await controller.MetrosACm(val),
            "3" => await controller.PulgadasACm(val),
            "4" => await controller.PiesAMetros(val),
            "5" => await controller.MillasAKm(val),
            _ => 0
        };
        view.MostrarResultado(res);
    }
    else
    {
        view.MostrarError("Valor inválido");
    }
}

async Task MenuMasa(ConversorController controller, ConsoleView view)
{
    view.MostrarMenuMasa();
    string subOp = Console.ReadLine();
    view.MostrarPedidoValor();

    if (double.TryParse(Console.ReadLine(), out double val))
    {
        double res = subOp switch
        {
            "1" => await controller.KgAGramos(val),
            "2" => await controller.GramosAMg(val),
            "3" => await controller.LibrasAKg(val),
            "4" => await controller.OnzasAGramos(val),
            "5" => await controller.ToneladasAKg(val),
            _ => 0
        };
        view.MostrarResultado(res);
    }
    else
    {
        view.MostrarError("Valor inválido");
    }
}
