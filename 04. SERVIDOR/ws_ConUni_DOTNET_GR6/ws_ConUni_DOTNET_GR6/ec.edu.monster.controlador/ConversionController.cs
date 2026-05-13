using Microsoft.AspNetCore.Mvc;
using ec.edu.monster.servicio;

namespace ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        // ============ TEMPERATURA ============
        [HttpGet("CelsiusAFahrenheit/{val}")]
        public ActionResult<double> GetCelsiusAFahrenheit(double val)
        {
            try
            {
                var resultado = _conversionService.CelsiusAFahrenheit(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("FahrenheitACelsius/{val}")]
        public ActionResult<double> GetFahrenheitACelsius(double val)
        {
            try
            {
                var resultado = _conversionService.FahrenheitACelsius(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("CelsiusAKelvin/{val}")]
        public ActionResult<double> GetCelsiusAKelvin(double val)
        {
            try
            {
                var resultado = _conversionService.CelsiusAKelvin(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("KelvinACelsius/{val}")]
        public ActionResult<double> GetKelvinACelsius(double val)
        {
            try
            {
                var resultado = _conversionService.KelvinACelsius(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("FahrenheitAKelvin/{val}")]
        public ActionResult<double> GetFahrenheitAKelvin(double val)
        {
            try
            {
                var resultado = _conversionService.FahrenheitAKelvin(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("KelvinAFahrenheit/{val}")]
        public ActionResult<double> GetKelvinAFahrenheit(double val)
        {
            try
            {
                var resultado = _conversionService.KelvinAFahrenheit(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // ============ LONGITUD ============
        [HttpGet("KmAMetros/{val}")]
        public ActionResult<double> GetKmAMetros(double val)
        {
            try
            {
                var resultado = _conversionService.KmAMetros(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("MetrosACm/{val}")]
        public ActionResult<double> GetMetrosACm(double val)
        {
            try
            {
                var resultado = _conversionService.MetrosACm(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("PulgadasACm/{val}")]
        public ActionResult<double> GetPulgadasACm(double val)
        {
            try
            {
                var resultado = _conversionService.PulgadasACm(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("PiesAMetros/{val}")]
        public ActionResult<double> GetPiesAMetros(double val)
        {
            try
            {
                var resultado = _conversionService.PiesAMetros(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("MillasAKm/{val}")]
        public ActionResult<double> GetMillasAKm(double val)
        {
            try
            {
                var resultado = _conversionService.MillasAKm(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // ============ MASA ============
        [HttpGet("KgAGramos/{val}")]
        public ActionResult<double> GetKgAGramos(double val)
        {
            try
            {
                var resultado = _conversionService.KgAGramos(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("GramosAMg/{val}")]
        public ActionResult<double> GetGramosAMg(double val)
        {
            try
            {
                var resultado = _conversionService.GramosAMg(val);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
