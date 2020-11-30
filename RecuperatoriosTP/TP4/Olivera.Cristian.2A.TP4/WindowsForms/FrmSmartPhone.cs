using Entidades;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FrmSmartPhone : Form
    {
        private SmartPhone smartPhone;

        #region Constructor
        /// <summary>
        /// Instancio el FrmSmartPhone
        /// </summary>
        public FrmSmartPhone()
        {
            InitializeComponent();
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad de solo lectura del smartphone del formulario
        /// </summary>
        public SmartPhone SmartPhone
        {
            get
            {
                return this.smartPhone;
            }
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Verifica que el usuario haya ingresado una marca antes de agregarlo, caso contrario tiro excepcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMarca.SelectedIndex == 0 || comboBoxMarca.SelectedIndex == 1 || comboBoxMarca.SelectedIndex == 2)
                {
                    this.smartPhone = new SmartPhone(0, comboBoxProducto.Text, float.Parse(labelPrecio.Text), comboBoxMarca.Text, SmartPhone.MapeoSistemaOperativo(comboBoxSO.Text), SmartPhone.MapeoMemoria(comboBoxMemoria.Text));

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new ProductoSinMarcaException("Se debe ingresar la marca del producto");
                }
            }
            catch(ProductoSinMarcaException ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Al cargar el form el combo box de producto, memoria y SO tienen un valor por default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSmartPhone_Load(object sender, EventArgs e)
        {
            this.comboBoxProducto.SelectedIndex = 0;
            this.comboBoxMemoria.SelectedIndex = 0;
            this.comboBoxSO.SelectedIndex = 0;
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
        /// Dependiendo la cantidad de memoria seleccionada especifico el precio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void comboBoxMemoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxMemoria.SelectedIndex)
            {
                case 0:
                    labelPrecio.Text = "280";
                    break;
                case 1:
                    labelPrecio.Text = "260";
                    break;
                default:
                    labelPrecio.Text = "220";
                    break;
            }
        }

        #endregion
    }
}