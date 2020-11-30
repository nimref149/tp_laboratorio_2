using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace WindowsForms
{
    public partial class FrmPantalla : Form
    {
        private Pantalla pantalla;

        #region Constructor
        /// <summary>
        ///Se instancia el FrmPantalla
        /// </summary>
        public FrmPantalla()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad de solo lectura de la pantalla del formulario
        /// </summary>
        public Pantalla Pantalla
        {
            get
            {
                return this.pantalla;
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Verifico que el usuario haya elegido marca antes de instanciar la pantalla, de no ser asi, lanzo una excepcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMarca.SelectedIndex == 0 || comboBoxMarca.SelectedIndex == 1 || comboBoxMarca.SelectedIndex == 2)
                {
                    this.pantalla = new Pantalla(0, comboBoxProducto.Text, float.Parse(labelPrecio.Text), comboBoxMarca.Text, Pantalla.MapeoPulgadas(comboBoxPulgadas.Text), Pantalla.MapeoResolucion(comboBoxResolucion.Text));

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new ProductoSinMarcaException("Se debe ingresar la marca del producto");
                }
            }
            catch (ProductoSinMarcaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
        
        /// <summary>
        /// Al presionar el boton asigno un DialogResult.Cancel para que no se agrege el producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Doy un valor por default al combo box de Producto, pulgadas y resolucion al cargar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPantalla_Load(object sender, EventArgs e)
        {
            this.comboBoxProducto.SelectedIndex = 0;
            this.comboBoxPulgadas.SelectedIndex = 0;
            this.comboBoxResolucion.SelectedIndex = 0;
        }

        /// <summary>
        /// Dependiendo la resolucion seleccionada especifico el precio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxResolucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxResolucion.SelectedIndex)
            {
                case 0:
                    labelPrecio.Text = "340";
                    break;
                case 1:
                    labelPrecio.Text = "400";
                    break;
                default:
                    labelPrecio.Text = "450";
                    break;
            }
        }

        #endregion
    }
}
