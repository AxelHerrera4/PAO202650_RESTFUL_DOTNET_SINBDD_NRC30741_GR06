namespace ec.edu.monster.servicio
{
    public class ConversionService : IConversionService
    {
        // ============ TEMPERATURA ============
        public double CelsiusAFahrenheit(double val) => (val * 9 / 5) + 32;

        public double FahrenheitACelsius(double val) => (val - 32) * 5 / 9;

        public double CelsiusAKelvin(double val) => val + 273.15;

        public double KelvinACelsius(double val) => val - 273.15;

        public double FahrenheitAKelvin(double val) => (val - 32) * 5 / 9 + 273.15;

        public double KelvinAFahrenheit(double val) => (val - 273.15) * 9 / 5 + 32;

        // ============ LONGITUD ============
        public double KmAMetros(double val) => val * 1000;

        public double MetrosACm(double val) => val * 100;

        public double PulgadasACm(double val) => val * 2.54;

        public double PiesAMetros(double val) => val * 0.3048;

        public double MillasAKm(double val) => val * 1.60934;

        // ============ MASA ============
        public double KgAGramos(double val) => val * 1000;

        public double GramosAMg(double val) => val * 1000;
    }
}
