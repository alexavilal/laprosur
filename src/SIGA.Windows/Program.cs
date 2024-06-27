using System;
using System.Windows.Forms;

namespace SIGA.Windows
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SIGA.Windows.Ventas.Formularios.frmRegistroVentas());

            Application.Run(new SIGA.Windows.MDISIGA());

            // Application.Run(new SIGA.Windows.Form2());
        }
    }
}
