using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FrmPrincipal : Form
    {
        public DataTable tabla;
        public SqlDataAdapter dA;
        public BaseDeDatos baseDeDatos;

        /// <summary>
        /// Incia instancia del form y configura los distintos objetos
        /// </summary>
        public FrmPrincipal()
        {
            InitializeComponent();
            baseDeDatos = new BaseDeDatos();
            this.dataGridView1 = baseDeDatos.ConfigurarGrilla(this.dataGridView1);
            this.tabla = new DataTable("historialVentas");
            this.dA = this.baseDeDatos.ConfigurarDataAdapter("historialVentas");

            try
            {
                this.dA.Fill(this.tabla);
                this.dataGridView1.DataSource = this.tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Muestra el form de SmartPhones y oculta este
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSmartPhone_Click(object sender, EventArgs e)
        {
            FrmDatosSmartPhone frmSP = new FrmDatosSmartPhone();
            this.Hide();
            frmSP.Show();
            
        }

        /// <summary>
        /// Muestra el form de pantallas y oculta este
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPantalla_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDatosPantalla frmPantalla = new FrmDatosPantalla();
            frmPantalla.ShowDialog();
        }


        /// <summary>
        /// Realizo un update antes de cerrar el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.dA.Update(this.tabla);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Cuando el form esta cerrado realiza un exit de la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
