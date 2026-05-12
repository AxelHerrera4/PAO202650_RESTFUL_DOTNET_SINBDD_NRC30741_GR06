using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIESC_ConUni_DotNet_GR6
{
    public partial class FormConversor : Form
    {
        // URL base de tu API REST
        private const string ApiBaseUrl = "http://localhost:8090/api/conversor";

        public FormConversor()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Inicializar opciones de Categoría
            cmbCategoria.Items.AddRange(new string[] { "LONGITUD", "TEMPERATURA", "MASA" });
            cmbCategoria.SelectedIndex = 1; // Seleccionar TEMPERATURA por defecto
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOperacion.Items.Clear();
            string categoria = cmbCategoria.SelectedItem.ToString();

            // Actualizar el título dinámico
            lblTituloPrincipal.Text = $"CONVERSOR MONSTER | {categoria}";

            if (categoria == "LONGITUD")
            {
                cmbOperacion.Items.AddRange(new string[]
                {
                    "Kilometros a Metros",
                    "Metros a Centimetros",
                    "Pulgadas a Centimetros",
                    "Pies a Metros",
                    "Millas a Kilometros"
                });
                lblIngresaValor.Text = "Ingresa unidades de longitud";
            }
            else if (categoria == "TEMPERATURA")
            {
                cmbOperacion.Items.AddRange(new string[]
                {
                    "Celsius a Fahrenheit",
                    "Fahrenheit a Celsius",
                    "Celsius a Kelvin",
                    "Kelvin a Celsius",
                    "Fahrenheit a Kelvin",
                    "Kelvin a Fahrenheit"
                });
                lblIngresaValor.Text = "Ingresa grados";
            }
            else if (categoria == "MASA")
            {
                cmbOperacion.Items.AddRange(new string[]
                {
                    "Kilogramos a Gramos",
                    "Gramos a Kilogramos",
                    "Libras a Kilogramos",
                    "Onzas a Gramos"
                });
                lblIngresaValor.Text = "Ingresa unidades de masa";
            }

            if (cmbOperacion.Items.Count > 0)
            {
                cmbOperacion.SelectedIndex = 0;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtValor.Clear();
            lblResultado.Text = "Esperando conversion...";
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnConvertir_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtValor.Text, out double valor))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblResultado.Text = "Procesando...";
            btnConvertir.Enabled = false;

            try
            {
                string operacion = cmbOperacion.SelectedItem.ToString();
                string endpoint = ObtenerEndpoint(operacion);

                if (string.IsNullOrEmpty(endpoint))
                {
                    MessageBox.Show("Operación no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblResultado.Text = "Error.";
                    return;
                }

                // Construir la URL completa
                string url = $"{ApiBaseUrl}/{endpoint}";

                using (HttpClient client = new HttpClient())
                {
                    // Aumentar el timeout si es necesario
                    client.Timeout = TimeSpan.FromSeconds(30);

                    // Realizar la solicitud GET
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string resultadoStr = await response.Content.ReadAsStringAsync();
                        double resultado = double.Parse(resultadoStr);
                        lblResultado.Text = resultado.ToString("G");
                    }
                    else
                    {
                        MessageBox.Show($"Error del servidor: {response.StatusCode}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblResultado.Text = "Error.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al contactar el servicio: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResultado.Text = "Error.";
            }
            finally
            {
                btnConvertir.Enabled = true;
            }
        }

        private string ObtenerEndpoint(string operacion)
        {
            switch (operacion)
            {
                // TEMPERATURA
                case "Celsius a Fahrenheit": return "CelsiusAFahrenheit/" + txtValor.Text;
                case "Fahrenheit a Celsius": return "FahrenheitACelsius/" + txtValor.Text;
                case "Celsius a Kelvin": return "CelsiusAKelvin/" + txtValor.Text;
                case "Kelvin a Celsius": return "KelvinACelsius/" + txtValor.Text;
                case "Fahrenheit a Kelvin": return "FahrenheitAKelvin/" + txtValor.Text;
                case "Kelvin a Fahrenheit": return "KelvinAFahrenheit/" + txtValor.Text;

                // LONGITUD
                case "Kilometros a Metros": return "KmAMetros/" + txtValor.Text;
                case "Metros a Centimetros": return "MetrosACm/" + txtValor.Text;
                case "Pulgadas a Centimetros": return "PulgadasACm/" + txtValor.Text;
                case "Pies a Metros": return "PiesAMetros/" + txtValor.Text;
                case "Millas a Kilometros": return "MillasAKm/" + txtValor.Text;

                // MASA
                case "Kilogramos a Gramos": return "KgAGramos/" + txtValor.Text;
                case "Gramos a Kilogramos": return "GramosAMg/" + txtValor.Text;
                case "Libras a Kilogramos": return "LibrasAKg/" + txtValor.Text;
                case "Onzas a Gramos": return "OnzasAGramos/" + txtValor.Text;

                default: return null;
            }
        }
    }
}
