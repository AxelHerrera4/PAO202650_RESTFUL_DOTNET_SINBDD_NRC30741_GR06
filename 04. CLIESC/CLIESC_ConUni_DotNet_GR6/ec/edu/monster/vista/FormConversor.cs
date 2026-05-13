using System;
using System.Drawing;
using System.Windows.Forms;
using ec.edu.monster.controlador;
using ec.edu.monster.modelo;

namespace ec.edu.monster.vista
{
    public partial class FormConversor : Form
    {
        private ConversorControlador controlador;

        public FormConversor()
        {
            InitializeComponent();
            controlador = new ConversorControlador();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            cmbCategoria.Items.AddRange(new string[] { "LONGITUD", "TEMPERATURA", "MASA" });
            cmbCategoria.SelectedIndex = 1;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbOperacion.Items.Clear();
            string categoria = cmbCategoria.SelectedItem.ToString();

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
                lblIngresaValor.Text = "Ingresa grados Celsius";
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
                var operacion = new ConversorOperacion
                {
                    Categoria = cmbCategoria.SelectedItem.ToString(),
                    Operacion = cmbOperacion.SelectedItem.ToString(),
                    Valor = valor
                };

                operacion = await controlador.ConvertirAsync(operacion);

                if (operacion.Mensaje == "Éxito")
                {
                    lblResultado.Text = operacion.Resultado.ToString("G");
                }
                else
                {
                    MessageBox.Show(operacion.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblResultado.Text = "Error.";
                }
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
