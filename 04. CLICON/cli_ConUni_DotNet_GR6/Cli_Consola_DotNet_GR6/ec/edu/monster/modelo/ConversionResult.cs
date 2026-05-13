namespace ec.edu.monster.modelo
{
    public class ConversionResult
    {
        public double Result { get; set; }
        public string ConversionType { get; set; }
        public double InputValue { get; set; }

        public ConversionResult()
        {
        }

        public ConversionResult(double result, string conversionType, double inputValue)
        {
            Result = result;
            ConversionType = conversionType;
            InputValue = inputValue;
        }
    }
}
