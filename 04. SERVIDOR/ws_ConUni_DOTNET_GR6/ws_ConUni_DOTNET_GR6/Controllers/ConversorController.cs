using Microsoft.AspNetCore.Mvc;

namespace ws_ConUni_DOTNET_GR6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversorController : ControllerBase
    {
        // ============ TEMPERATURA ============
        [HttpGet("CelsiusAFahrenheit/{val}")]
        public double GetCelsiusAFahrenheit(double val) => (val * 9 / 5) + 32;

        [HttpGet("FahrenheitACelsius/{val}")]
        public double GetFahrenheitACelsius(double val) => (val - 32) * 5 / 9;

        [HttpGet("CelsiusAKelvin/{val}")]
        public double GetCelsiusAKelvin(double val) => val + 273.15;

        [HttpGet("KelvinACelsius/{val}")]
        public double GetKelvinACelsius(double val) => val - 273.15;

        [HttpGet("FahrenheitAKelvin/{val}")]
        public double GetFahrenheitAKelvin(double val) => (val - 32) * 5 / 9 + 273.15;

        [HttpGet("KelvinAFahrenheit/{val}")]
        public double GetKelvinAFahrenheit(double val) => (val - 273.15) * 9 / 5 + 32;

        // ============ LONGITUD ============
        [HttpGet("KmAMetros/{val}")]
        public double GetKmAMetros(double val) => val * 1000;

        [HttpGet("MetrosACm/{val}")]
        public double GetMetrosACm(double val) => val * 100;

        [HttpGet("PulgadasACm/{val}")]
        public double GetPulgadasACm(double val) => val * 2.54;

        [HttpGet("PiesAMetros/{val}")]
        public double GetPiesAMetros(double val) => val * 0.3048;

        [HttpGet("MillasAKm/{val}")]
        public double GetMillasAKm(double val) => val * 1.60934;

        // ============ MASA ============
        [HttpGet("KgAGramos/{val}")]
        public double GetKgAGramos(double val) => val * 1000;

        [HttpGet("GramosAMg/{val}")]
        public double GetGramosAMg(double val) => val * 1000;

        [HttpGet("LibrasAKg/{val}")]
        public double GetLibrasAKg(double val) => val * 0.453592;

        [HttpGet("OnzasAGramos/{val}")]
        public double GetOnzasAGramos(double val) => val * 28.3495;

        [HttpGet("ToneladasAKg/{val}")]
        public double GetToneladasAKg(double val) => val * 1000;
    }
}
