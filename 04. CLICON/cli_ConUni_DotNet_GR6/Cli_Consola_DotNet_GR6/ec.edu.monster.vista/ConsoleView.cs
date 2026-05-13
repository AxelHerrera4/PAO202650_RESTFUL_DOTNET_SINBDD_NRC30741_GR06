using System;

namespace ec.edu.monster.vista
{
    public class ConsoleView
    {
        public void MostrarEncabezado()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("   CLIENTE C# - CONVERSOR ESPE      ");
            Console.WriteLine("====================================");
        }

        public (string user, string pass) ObtenerCredenciales()
        {
            Console.Write("Usuario: ");
            string user = Console.ReadLine();
            Console.Write("Contraseña: ");
            string pass = Console.ReadLine();
            return (user, pass);
        }

        public void MostrarErrorCredenciales()
        {
            Console.WriteLine("\n[!] Credenciales incorrectas. Intente de nuevo.");
            Console.WriteLine("Presione cualquier tecla para reintentar...");
            Console.ReadKey();
        }

        public void MostrarAccesoConcedido()
        {
            Console.WriteLine("\n[+] Acceso concedido.\n");
            System.Threading.Thread.Sleep(1000);
        }

        public string MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Conversiones de Temperatura");
            Console.WriteLine("2. Conversiones de Longitud");
            Console.WriteLine("3. Conversiones de Masa");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            return Console.ReadLine();
        }

        public (string subOp, double valor) MostrarMenuTemperatura()
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
                return (subOp, val);
            }
            return (subOp, 0); // O manejar error
        }

        public (string subOp, double valor) MostrarMenuLongitud()
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
                return (subOp, val);
            }
            return (subOp, 0);
        }

        public (string subOp, double valor) MostrarMenuMasa()
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
                return (subOp, val);
            }
            return (subOp, 0);
        }

        public void MostrarResultado(double res)
        {
            Console.WriteLine($">> Resultado: {res:N2}");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        public void MostrarError(string mensaje)
        {
            Console.WriteLine($"\n[!] Error: {mensaje}");
            Console.ReadKey();
        }

        public void MostrarDespedida()
        {
            Console.WriteLine("\nGracias por usar ConUni. Presione cualquier tecla para cerrar.");
            Console.ReadKey();
        }

        public void OpcionInvalida()
        {
            Console.WriteLine("Opción no válida.");
            System.Threading.Thread.Sleep(1000);
        }
    }
}