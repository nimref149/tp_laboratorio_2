using Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsForms
{
    public delegate void DelegadoHilo();

    public partial class FrmDatosSmartPhone : Form
    {
        private DataTable tabla;
        private SqlDataAdapter dA;
        private Thread hiloSecundario;
        private Vendedora vendedora;
        private BaseDeDatos baseDeDatos;

        public event DelegadoHilo EjecutarHilo;

        #region Constructor
        /// <summary>
        /// Constructor del form datos, dentro se configura el data adapter, data table y se asocia al evento el metodo que inicia el
        /// hilo secundario
        /// </summary>
        public FrmDatosSmartPhone()
        {
            this.baseDeDatos = new BaseDeDatos();
            this.vendedora = new Vendedora();
            this.hiloSecundario = new Thread(this.ComprobarLista);
            this.EjecutarHilo += Hilo_EjecutarHilo;
            InitializeComponent();
            this.dA = baseDeDatos.ConfigurarDataAdapter("smartPhone");
            this.tabla = baseDeDatos.ConfigurarDataTable("smartPhone");
            this.dataGridView1 = this.baseDeDatos.ConfigurarGrilla(this.dataGridView1);

            this.StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion

        #region Manejadores de eventos
        /// <summary>
        /// Una vez se cargue el form se llena mediante el fill la data table, e inicia el hilo secundario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmrDatosSmartPhone_Load(object sender, EventArgs e)
        {
            try
            {
                this.dA.Fill(this.tabla);
                this.dataGridView1.DataSource = this.tabla;
                this.EjecutarHilo.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Se agrega una venta a la data table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlta_Click(object sender, EventArgs e)
        {
            FrmSmartPhone frm = new FrmSmartPhone();

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.tabla.NewRow();

                fila["producto"] = frm.SmartPhone.NombreProducto;
                fila["marca"] = frm.SmartPhone.Marca;
                fila["sistemaOperativo"] = frm.SmartPhone.SistemaOperativo;
                fila["memoria"] = frm.SmartPhone.Memoria;
                fila["precio"] = frm.SmartPhone.Precio;

                FrmPrincipal frm1 = new FrmPrincipal();

                DataRow auxFila = frm1.tabla.Rows[0];
                auxFila["cantidadTotalVentas"] = int.Parse(auxFila["cantidadTotalVentas"].ToString()) + 1;

                try
                {
                    frm1.dA.Update(frm1.tabla);
                    this.tabla.Rows.Add(fila);
                }
                catch (Exception ex)
                {
                }
            }
        }


        /// <summary>
        /// Se guarda en un archivo de texto la lista de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarTexto_Click(object sender, EventArgs e)
        {
            if(vendedora.Guardar("SmartPhone.txt", this.vendedora.ToString()))
            {
                MessageBox.Show("El archivo se guardo con exito");
            }
        }

        /// <summary>
        /// Se lee el archivo de texto que contiene la lista de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeerTexto_Click(object sender, EventArgs e)
        {
            string datos;

            Mostrar frm = new Mostrar();

            vendedora.Leer("SmartPhone.txt", out datos);
            frm.richTextBox1.Text = datos;
            frm.ShowDialog();
        }

        /// <summary>
        /// Guarda en un archivo XML la lista de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarXml_Click(object sender, EventArgs e)
        {
            if (Vendedora.GuardarXml("SmartPhone.xml",this.vendedora))
            {
                MessageBox.Show("El archivo se guardo con exito");
            }
        }

        /// <summary>
        /// Al cerrarse el form se pregunta si quiere realizarlo, si presiona que no quiere salir sigue ejecutando el programa sin problemas
        /// caso contrario se cierra y se aborta el hilo secundario si este esta vivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDatosSmartPhone_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("¿Seguro que quiere salir del sistema?", "Consulta",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true; 
            }
            else
            {
                try
                {
                    FrmPrincipal frm = new FrmPrincipal();
                    this.EjecutarHilo.Invoke(); 
                    frm.Show(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Metodo encargado de iniciar el hilo comprobando siempre que este muerto antes de iniciarlo, caso contrario realizo el abort
        /// </summary>
        private void Hilo_EjecutarHilo()
        {
            if (!this.hiloSecundario.IsAlive)
            {
                this.hiloSecundario.Start(); 
            }
            else
            {
                this.hiloSecundario.Abort(); 
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo asociado al hilo, cada 2 segundos comprueba si la lista de productos es distinta a la cantidad de rows en el
        /// datagridview, de ser asi se actualiza la lista de productos con el contenido nuevo.
        /// </summary>
        private void ComprobarLista()
        {
            do
            {
                Thread.Sleep(1000);

                if (this.vendedora.ListaDeProductos.Count != this.dataGridView1.Rows.Count)
                {
                    if (this.labelInforma.InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.labelInforma.Text = "Lista actualizada"; 
                        }
                        );
                    }
                    this.CargarLista();
                }
                else
                {
                    if (this.labelInforma.InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.labelInforma.Text = "Los datos ya estan sincronizados"; 
                        }
                        );
                    }
                }
            } while (this.hiloSecundario.IsAlive);
        }

        /// <summary>
        /// Metodo mediante el cual se carga la lista con los elementos del datagridview y realiza el update a la base de datos
        /// </summary>
        private void CargarLista()
        {
            try
            {
                foreach (DataRow fila in this.tabla.Rows)
                {
                    SmartPhone sP = new SmartPhone(int.Parse(fila["idVenta"].ToString()),
                                                        fila["producto"].ToString(),
                                                        float.Parse(fila["precio"].ToString()),
                                                        fila["marca"].ToString(),
                                                        SmartPhone.MapeoSistemaOperativo(fila["sistemaOperativo"].ToString()),
                                                        SmartPhone.MapeoMemoria(fila["memoria"].ToString()));

                    this.vendedora += sP;
                }


                this.dA.Update(this.tabla);
            }

            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        #endregion

    }
}