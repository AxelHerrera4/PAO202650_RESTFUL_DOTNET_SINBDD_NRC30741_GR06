using System;
using System.Threading.Tasks;
using ec.edu.monster.modelo;
using ec.edu.monster.vista;

namespace ec.edu.monster.controlador
{
    public class AppController
    {
        private readonly ConsoleView _view;
        private readonly AuthService _authService;
        private readonly ConverterService _converterService;

        public AppController(ConsoleView view, AuthService authService, ConverterService converterService)
        {
            _view = view;
            _authService = authService;
            _converterService = converterService;
        }

        public async Task StartAsync()
        {
            if (!Autenticar())
                return;

            await MostrarMenuPrincipalAsync();
        }

        private bool Autenticar()
        {
            while (true)
            {
                _view.MostrarEncabezado();
                var (user, pass) = _view.ObtenerCredenciales();

                if (_authService.Login(user, pass))
                {
                    _view.MostrarAccesoConcedido();
                    return true;
                }
                else
                {
                    _view.MostrarErrorCredenciales();
                }
            }
        }

        private async Task MostrarMenuPrincipalAsync()
        {
            try
            {
                bool continuar = true;
                while (continuar)
                {
                    string opcion = _view.MostrarMenuPrincipal();

                    switch (opcion)
                    {
                        case "1":
                            await ProcesarTemperaturaAsync();
                            break;
                        case "2":
                            await ProcesarLongitudAsync();
                            break;
                        case "3":
                            await ProcesarMasaAsync();
                            break;
                        case "4":
                            continuar = false;
                            break;
                        default:
                            _view.OpcionInvalida();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                _view.MostrarError($"Error de comunicación: {ex.Message}");
            }
            finally
            {
                _view.MostrarDespedida();
            }
        }

        private async Task ProcesarTemperaturaAsync()
        {
            var (subOp, valor) = _view.MostrarMenuTemperatura();
            if (valor != 0 || subOp != "")
            {
                double res = await _converterService.ConvertirTemperaturaAsync(subOp, valor);
                _view.MostrarResultado(res);
            }
        }

        private async Task ProcesarLongitudAsync()
        {
            var (subOp, valor) = _view.MostrarMenuLongitud();
            if (valor != 0 || subOp != "")
            {
                double res = await _converterService.ConvertirLongitudAsync(subOp, valor);
                _view.MostrarResultado(res);
            }
        }

        private async Task ProcesarMasaAsync()
        {
            var (subOp, valor) = _view.MostrarMenuMasa();
            if (valor != 0 || subOp != "")
            {
                double res = await _converterService.ConvertirMasaAsync(subOp, valor);
                _view.MostrarResultado(res);
            }
        }
    }
}