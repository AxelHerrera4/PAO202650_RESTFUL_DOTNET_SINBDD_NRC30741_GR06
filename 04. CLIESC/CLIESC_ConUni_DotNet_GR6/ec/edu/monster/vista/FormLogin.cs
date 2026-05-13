using System;
using System.Drawing;
using System.Windows.Forms;
using ec.edu.monster.controlador;
using ec.edu.monster.modelo;

namespace ec.edu.monster.vista
{
    public partial class FormLogin : Form
    {
        private ConversorControlador controlador;

        public FormLogin()
        {
            InitializeComponent();
            controlador = new ConversorControlador();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var usuario = new UsuarioLogin
            {
                Usuario = txtUsuario.Text,
                Contrasena = txtPass.Text
            };

            if (controlador.ValidarLogin(usuario))
            {
                FormConversor formConversor = new FormConversor();
                this.Hide();
                formConversor.FormClosed += (s, args) => this.Show();
                formConversor.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Clear();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
