using ec.edu.monster.servicio;
using Xunit;

namespace ec.edu.monster.pruebas
{
    public class ConversionUnidadesPrueba
    {
        private readonly IConversionService _conversionService;

        public ConversionUnidadesPrueba()
        {
            _conversionService = new ConversionService();
        }

        // ============ PRUEBAS DE TEMPERATURA ============
        [Theory]
        [InlineData(0, 32)]           // 0°C = 32°F
        [InlineData(100, 212)]        // 100°C = 212°F
        [InlineData(-40, -40)]        // -40°C = -40°F
        public void CelsiusAFahrenheit_ShouldReturnCorrectResult(double celsius, double expected)
        {
            // Act
            var result = _conversionService.CelsiusAFahrenheit(celsius);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        [Theory]
        [InlineData(32, 0)]           // 32°F = 0°C
        [InlineData(212, 100)]        // 212°F = 100°C
        [InlineData(-40, -40)]        // -40°F = -40°C
        public void FahrenheitACelsius_ShouldReturnCorrectResult(double fahrenheit, double expected)
        {
            // Act
            var result = _conversionService.FahrenheitACelsius(fahrenheit);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        [Theory]
        [InlineData(0, 273.15)]       // 0°C = 273.15K
        [InlineData(100, 373.15)]     // 100°C = 373.15K
        public void CelsiusAKelvin_ShouldReturnCorrectResult(double celsius, double expected)
        {
            // Act
            var result = _conversionService.CelsiusAKelvin(celsius);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        [Theory]
        [InlineData(273.15, 0)]       // 273.15K = 0°C
        [InlineData(373.15, 100)]     // 373.15K = 100°C
        public void KelvinACelsius_ShouldReturnCorrectResult(double kelvin, double expected)
        {
            // Act
            var result = _conversionService.KelvinACelsius(kelvin);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        [Theory]
        [InlineData(32, 273.15)]      // 32°F = 273.15K
        [InlineData(212, 373.15)]     // 212°F = 373.15K
        public void FahrenheitAKelvin_ShouldReturnCorrectResult(double fahrenheit, double expected)
        {
            // Act
            var result = _conversionService.FahrenheitAKelvin(fahrenheit);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        [Theory]
        [InlineData(273.15, 32)]      // 273.15K = 32°F
        [InlineData(373.15, 212)]     // 373.15K = 212°F
        public void KelvinAFahrenheit_ShouldReturnCorrectResult(double kelvin, double expected)
        {
            // Act
            var result = _conversionService.KelvinAFahrenheit(kelvin);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        // ============ PRUEBAS DE LONGITUD ============
        [Theory]
        [InlineData(1, 1000)]         // 1 km = 1000 m
        [InlineData(2.5, 2500)]       // 2.5 km = 2500 m
        public void KmAMetros_ShouldReturnCorrectResult(double km, double expected)
        {
            // Act
            var result = _conversionService.KmAMetros(km);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        [Theory]
        [InlineData(1, 100)]          // 1 m = 100 cm
        [InlineData(5.5, 550)]        // 5.5 m = 550 cm
        public void MetrosACm_ShouldReturnCorrectResult(double metros, double expected)
        {
            // Act
            var result = _conversionService.MetrosACm(metros);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        [Theory]
        [InlineData(1, 2.54)]         // 1 pulgada = 2.54 cm
        [InlineData(10, 25.4)]        // 10 pulgadas = 25.4 cm
        public void PulgadasACm_ShouldReturnCorrectResult(double pulgadas, double expected)
        {
            // Act
            var result = _conversionService.PulgadasACm(pulgadas);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        [Theory]
        [InlineData(1, 0.3048)]       // 1 pie = 0.3048 m
        [InlineData(10, 3.048)]       // 10 pies = 3.048 m
        public void PiesAMetros_ShouldReturnCorrectResult(double pies, double expected)
        {
            // Act
            var result = _conversionService.PiesAMetros(pies);

            // Assert
            Assert.Equal(expected, result, precision: 4);
        }

        [Theory]
        [InlineData(1, 1.60934)]      // 1 milla = 1.60934 km
        [InlineData(2, 3.21868)]      // 2 millas = 3.21868 km
        public void MillasAKm_ShouldReturnCorrectResult(double millas, double expected)
        {
            // Act
            var result = _conversionService.MillasAKm(millas);

            // Assert
            Assert.Equal(expected, result, precision: 5);
        }

        // ============ PRUEBAS DE MASA ============
        [Theory]
        [InlineData(1, 1000)]         // 1 kg = 1000 g
        [InlineData(2.5, 2500)]       // 2.5 kg = 2500 g
        public void KgAGramos_ShouldReturnCorrectResult(double kg, double expected)
        {
            // Act
            var result = _conversionService.KgAGramos(kg);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }

        [Theory]
        [InlineData(1000, 1000000)]   // 1000 g = 1000000 mg
        [InlineData(500, 500000)]     // 500 g = 500000 mg
        public void GramosAMg_ShouldReturnCorrectResult(double gramos, double expected)
        {
            // Act
            var result = _conversionService.GramosAMg(gramos);

            // Assert
            Assert.Equal(expected, result, precision: 2);
        }
    }
}
