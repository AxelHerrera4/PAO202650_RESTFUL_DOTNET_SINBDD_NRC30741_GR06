namespace ec.edu.monster.servicio
{
    public interface IConversionService
    {
        // ============ TEMPERATURA ============
        double CelsiusAFahrenheit(double val);
        double FahrenheitACelsius(double val);
        double CelsiusAKelvin(double val);
        double KelvinACelsius(double val);
        double FahrenheitAKelvin(double val);
        double KelvinAFahrenheit(double val);

        // ============ LONGITUD ============
        double KmAMetros(double val);
        double MetrosACm(double val);
        double PulgadasACm(double val);
        double PiesAMetros(double val);
        double MillasAKm(double val);

        // ============ MASA ============
        double KgAGramos(double val);
        double GramosAMg(double val);
    }
}
