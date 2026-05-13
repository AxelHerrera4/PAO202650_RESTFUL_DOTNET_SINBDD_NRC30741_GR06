namespace ec.edu.monster.modelo
{
    public class ConversorOperacion
    {
        public string Categoria { get; set; }
        public string Operacion { get; set; }
        public double Valor { get; set; }
        public double Resultado { get; set; }
        public string Mensaje { get; set; }
    }

    public class UsuarioLogin
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
