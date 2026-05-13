namespace ec.edu.monster.modelo
{
    public class ConversionRequest
    {
        public double Valor { get; set; }
    }

    public class ConversionResponse
    {
        public double Resultado { get; set; }
        public string Tipo { get; set; }
        public string Unidad { get; set; }
    }
}
