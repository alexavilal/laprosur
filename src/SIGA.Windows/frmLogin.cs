using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SIGA.Windows
{
    public partial class frmLogin :Form
    {
        public frmLogin()
        {
            InitializeComponent();

            //MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            //// Configure color schema
            //materialSkinManager.ColorScheme = new ColorScheme(
            //    Primary.Blue400, Primary.Blue500,
            //    Primary.Blue500, Accent.LightBlue200,
            //    TextShade.WHITE
            //);

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
          
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            SIGA.Business.Seguridad.UsuarioBusiness objUsuario = new SIGA.Business.Seguridad.UsuarioBusiness();
           
            string Mensaje = string.Empty;

            try
            {
                if (txtUsername.Text.Length == 0 || txtPassword.Text.Length == 0)
                {

                    MessageBox.Show("Debe ingresar usuario y contraseña", "SIGA");
                    return;
                }

                else
                {
                    var result = objUsuario.ValidarIngresoUsuario(txtUsername.Text, txtPassword.Text, ref Mensaje);

                    if (result == true)
                    {

                       
                        SIGA.Entities.Seguridad.Usuario objUsuarioEntidad = new SIGA.Entities.Seguridad.Usuario()
                        {
                            ApellidoPaterno = string.Empty,
                            ApellidoMaterno = string.Empty,
                            Nombre = string.Empty,
                            IdentificadorUsuario = txtUsername.Text,
                            CorreoElectronico = string.Empty,
                            CodigoEstadoUsuario = string.Empty
                        };

                        var resultUsuario = objUsuario.ObtenerUsuarios(objUsuarioEntidad).SingleOrDefault();

                        if (resultUsuario != null)
                        {
                            UsuarioLogeo.Codigo = Convert.ToInt16(resultUsuario.CodigoUsuario);
                            UsuarioLogeo.Nombre = resultUsuario.Nombre.ToString() + " " + resultUsuario.ApellidoPaterno.ToString() + " " + resultUsuario.ApellidoMaterno.ToString();
                            UsuarioLogeo.UsuarioSession = txtUsername.Text;
                            this.Close();
                        }



                    }
                    else
                    {
                        MessageBox.Show(Mensaje);

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            txtUsername.BorderStyle = BorderStyle.None;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.BorderStyle = BorderStyle.Fixed3D;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.BorderStyle = BorderStyle.None;
        }

        // Permitir la tecla Enter para enviar el formulario
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnLogin.PerformClick();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }

    }
}
