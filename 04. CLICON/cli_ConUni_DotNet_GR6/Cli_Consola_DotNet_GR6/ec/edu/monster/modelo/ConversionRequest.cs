namespace ec.edu.monster.modelo
{
    public class ConversionRequest
    {
        public double Value { get; set; }
        public string ConversionType { get; set; }

        public ConversionRequest()
        {
        }

        public ConversionRequest(double value, string conversionType)
        {
            Value = value;
            ConversionType = conversionType;
        }
    }
}
