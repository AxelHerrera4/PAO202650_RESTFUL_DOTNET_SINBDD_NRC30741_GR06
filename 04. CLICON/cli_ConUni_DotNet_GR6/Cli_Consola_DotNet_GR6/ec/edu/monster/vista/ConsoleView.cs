using System;

namespace ec.edu.monster.vista
{
    public class ConsoleView
    {
        public void MostrarLoginUI()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("   CLIENTE C# - CONVERSOR ESPE      ");
            Console.WriteLine("====================================");
            Console.Write("Usuario: ");
        }

        public void MostrarPedidoPassword()
        {
            Console.Write("Contraseña: ");
        }

        public void MostrarAccesoConcedido()
        {
            Console.WriteLine("\n[+] Acceso concedido.\n");
            System.Threading.Thread.Sleep(1000);
        }

        public void MostrarAccesoDenegado()
        {
            Console.WriteLine("\n[!] Credenciales incorrectas. Intente de nuevo.");
            Console.WriteLine("Presione cualquier tecla para reintentar...");
            Console.ReadKey();
        }

        public void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Conversiones de Temperatura");
            Console.WriteLine("2. Conversiones de Longitud");
            Console.WriteLine("3. Conversiones de Masa");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
        }

        public void MostrarMenuTemperatura()
        {
            Console.Clear();
            Console.WriteLine("\n-- TEMPERATURA --");
            Console.WriteLine("1. Celsius a Fahrenheit");
            Console.WriteLine("2. Fahrenheit a Celsius");
            Console.WriteLine("3. Celsius a Kelvin");
            Console.WriteLine("4. Kelvin a Celsius");
            Console.WriteLine("5. Fahrenheit a Kelvin");
            Console.WriteLine("6. Kelvin a Fahrenheit");
            Console.Write("Seleccione: ");
        }

        public void MostrarMenuLongitud()
        {
            Console.Clear();
            Console.WriteLine("\n-- LONGITUD --");
            Console.WriteLine("1. Kilómetros a Metros");
            Console.WriteLine("2. Metros a Centímetros");
            Console.WriteLine("3. Pulgadas a Centímetros");
            Console.WriteLine("4. Pies a Metros");
            Console.WriteLine("5. Millas a Kilómetros");
            Console.Write("Seleccione: ");
        }

        public void MostrarMenuMasa()
        {
            Console.Clear();
            Console.WriteLine("\n-- MASA --");
            Console.WriteLine("1. Kilogramos a Gramos");
            Console.WriteLine("2. Gramos a Miligramos");
            Console.WriteLine("3. Libras a Kilogramos");
            Console.WriteLine("4. Onzas a Gramos");
            Console.WriteLine("5. Toneladas a Kilogramos");
            Console.Write("Seleccione: ");
        }

        public void MostrarPedidoValor()
        {
            Console.Write("Ingrese valor: ");
        }

        public void MostrarResultado(double resultado)
        {
            Console.WriteLine($">> Resultado: {resultado:N2}");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        public void MostrarError(string mensaje)
        {
            Console.WriteLine($"\n[!] Error: {mensaje}");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        public void MostrarDespedida()
        {
            Console.WriteLine("\nGracias por usar ConUni. Presione cualquier tecla para cerrar.");
            Console.ReadKey();
        }
    }
}
