using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLIESC_ConUni_DotNet_GR6.ec.edu.monster.controlador;

namespace CLIESC_ConUni_DotNet_GR6
{
    public partial class FormConversor : Form
    {
        private readonly ConversorController _controller;

        public FormConversor()
        {
            InitializeComponent();
            _controller = new ConversorController();
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
                string resultadoStr = await _controller.ConvertirAsync(operacion, txtValor.Text);
                double resultado = double.Parse(resultadoStr);
                lblResultado.Text = resultado.ToString("G");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResultado.Text = "Error.";
            }
            finally
            {
                btnConvertir.Enabled = true;
            }
        }
    }
}
