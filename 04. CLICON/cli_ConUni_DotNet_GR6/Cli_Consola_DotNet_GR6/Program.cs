using System;
using System.Threading.Tasks;
using ec.edu.monster.modelo;
using ec.edu.monster.vista;
using ec.edu.monster.controlador;

class Program
{
    static async Task Main(string[] args)
    {
        // 1. Instanciar los componentes MVC
        var authService = new AuthService();
        var converterService = new ConverterService("http://10.40.26.222:8090/");
        var view = new ConsoleView();

        // 2. Inyectar dependencias en el controlador
        var controller = new AppController(view, authService, converterService);

        // 3. Iniciar la aplicación
        await controller.StartAsync();

        // 4. Limpiar recursos (opcional pero buena práctica)
        converterService.Dispose();
    }
}
