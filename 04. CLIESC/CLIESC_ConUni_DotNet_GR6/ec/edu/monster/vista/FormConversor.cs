using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using ec.edu.monster.controlador;
using ec.edu.monster.modelo;

namespace ec.edu.monster.vista
{
    public partial class FormConversor : Form
    {
        private readonly ConversionController _controller;

        public FormConversor()
        {
            InitializeComponent();
            _controller = new ConversionController();
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

            var operaciones = ConversionModel.ObetenerOperaciones(categoria);
            cmbOperacion.Items.AddRange(operaciones.ToArray());
            lblIngresaValor.Text = ConversionModel.ObtenerPlaceholder(categoria);

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
                string endpoint = ConversionModel.GetEndpoint(operacion, txtValor.Text);

                if (string.IsNullOrEmpty(endpoint))
                {
                    MessageBox.Show("Operación no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblResultado.Text = "Error.";
                    return;
                }

                double resultado = await _controller.ConvertirAsync(endpoint);
                lblResultado.Text = resultado.ToString("G");
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
    }
}
