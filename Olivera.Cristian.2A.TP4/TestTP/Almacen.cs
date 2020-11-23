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
using System.Data.SqlClient;
using System.Threading;

namespace TestTP
{
    public partial class Almacen : Form
    {
        private Manzana _manzana;
        private Banana _banana;
        private Melocoton _melocoton;
        public Estante<Manzana> c_manzanas;
        public Estante<Banana> c_bananas;
        public Estante<Melocoton> c_melocotones;

        public Almacen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Muestra un mensaje de bienvenida al comenzar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Almacen_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido al sistema de Almacen De Frutas");
        }


        /// <summary>
        /// Se crea una instancia de cada clase e inicializa los atributos del form, manzana, banana y melocoton
        /// y se muestran por pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            this._manzana = new Manzana("verde", 2, "rio negro");
            this._banana = new Banana("amarillo", 5, "ecuador");
            this._melocoton = new Melocoton("rojo", 2.5, 53);

            MessageBox.Show(this._manzana.ToString());
            MessageBox.Show(this._banana.ToString());
            MessageBox.Show(this._melocoton.ToString());
        }




        /// <summary>
        /// Se crea la clase estante de cada fruta que se añadiran algunas frutas con sus respectivos datos, el peso y la cantidad maxima
        ///se mostraran los datos por pantalla de cada estante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.c_manzanas = new Estante<Manzana>(1.58, 3);
            this.c_bananas = new Estante<Banana>(15.96, 4);
            this.c_melocotones = new Estante<Melocoton>(21.5, 1);

            this.c_manzanas += new Manzana("roja", 1, "neuquen");
            this.c_manzanas += this._manzana;
            this.c_manzanas += new Manzana("amarilla", 3, "san juan");

            this.c_bananas += new Banana("verde", 3, "brasil");
            this.c_bananas += this._banana;

            this.c_melocotones += this._melocoton;

            MessageBox.Show(this.c_manzanas.ToString());

            MessageBox.Show(this.c_bananas.ToString());

            MessageBox.Show(this.c_melocotones.ToString());
        }



        /// <summary>
        /// Aca se serializa, deserializa una fruta y un estante de una fruta
        ///y se guarda el archivo xml en el escritorio con el nombre de la fruta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            Fruta aux = null;

            if (this._manzana.Xml("manzana.xml"))
            {
                MessageBox.Show("Manzana serializada OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }

            if (((IDeserializar)this._manzana).Xml("manzana.xml", out aux))
            {
                MessageBox.Show("Manzana deserializada OK");

                MessageBox.Show(((Manzana)aux).ToString());
            }
            else
            {
                MessageBox.Show("NO Deserializado");
            }

            if (this.c_manzanas.Xml("manzanas.xml"))
            {
                MessageBox.Show("Estante de Manzanas serializado OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }
        }

        /// <summary>
        /// Se intenta agregar frutas al estante y si se supera la cantidad maxima se lanzara una excepcion con un mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            
            try
            {
                this.c_melocotones += this._melocoton;
            }
            catch (EstanteLlenoException error)
            {
                MessageBox.Show(error.Message, "Error al agregar frutas al estante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
 
        /// <summary>
        /// Aca se lanzara un evento en caso de superarse el precio maximo de 55 pesos y se imprimira en un archivo de texto 
        ///la fecha(con hora, minutos y segundos) y el total del precio del estante en un reglon nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            
            Ticketador<Banana> manejador = new Ticketador<Banana>();

            this.c_bananas.EventoPrecio += new Estante<Banana>.DelegadoEventoPrecio(manejador.ManejadorEventoPrecio);

            this.c_bananas += new Banana("verde", 2, "argentina");

            this.c_bananas += new Banana("amarilla", 4, "ecuador");

            double precio = this.c_bananas.PrecioTotal;
        }

        

        /// <summary>
        /// Se obtiene de la base de datos el listado de las frutas y se muestra en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPunto6_Click(object sender, EventArgs e)
        {

            MessageBox.Show(Almacen.ObtenerListadoFrutas());

        }

        /// <summary>
        /// Se agregara nuevas frutas a la base de datos del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            if (Almacen.AgregarFrutas(this))
            {

                MessageBox.Show("Se agregaron a la Base de Datos frutas compradas");
                
            }
            else
            {
                MessageBox.Show("NO se agregaron las frutas a la Base de Datos");
            }
        }
        
         /// <summary>
         /// Aca se eliminara una fruta de la base de datos con el metodo de extencion correspondiente, en base al id, una sola vez
         /// si hay un error se lanzara una excepcion
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void btnPunto8_Click(object sender, EventArgs e)
        {
           
            int idD = 1;

            try
            {
                
                if (this.c_manzanas.EliminarFruta(idD))
                {
                    
                    MessageBox.Show("Se ha vendido la fruta con el id nro " + idD + " y se ha eliminado de la base de datos");
                    
                }
                else
                {
                     MessageBox.Show("No se ha eliminado la fruta de la base de datos");
                  
                }


            }

            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        /// <summary>
        /// Se obtiene la lista para la base de datos se creara un método que retorne (en formato de string) el contenido de la tabla de la base de datos y
        ///lo muestre en un MessageBox.(punto 6)
        /// </summary>
        /// <returns></returns>
        private static string ObtenerListadoFrutas()
        {
            StringBuilder frutas = new StringBuilder();

            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);

            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM [sp_lab_II].[dbo].[frutas]";

                SqlDataReader lector = comando.ExecuteReader();
                MessageBox.Show("Se mostrara el listado de frutas disponibles en el almacen");
                while (lector.Read() != false)
                {
                    frutas.AppendFormat("{0} - {1} - {2} - {3}\n", (int)lector[0], lector[1].ToString(), (double)lector[2], (double)lector[3]);
                }

                lector.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error en la conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }

            return frutas.ToString();
        }
        
        /// <summary>
        /// Permite agregar elementos,(frutas) a la base de datos
        /// </summary>
        /// <param name="frm"></param>
        /// <returns></returns>
        private static bool AgregarFrutas(Almacen frm)
        {
            bool retorno = true;

            int filas = 0;

            try
            {

                using (SqlConnection sqlConexion = new SqlConnection(Properties.Settings.Default.Conexion))
                {

                    sqlConexion.Open();
                    MessageBox.Show("Base de datos se cargo exitosamente");
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = sqlConexion;
                    comando.CommandType = CommandType.Text;

                    comando.CommandText = "INSERT INTO [frutas] ([nombre],[peso],[precio])" + " VALUES (@nombre, @peso, @precio)";
                    comando.Parameters.AddWithValue("@nombre", frm._manzana.Nombre);
                    comando.Parameters.AddWithValue("@peso", frm._manzana.Peso);
                    comando.Parameters.AddWithValue("@precio", frm.c_manzanas.PrecioTotal / frm.c_manzanas.Elementos.Count);

                    filas += comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                    comando.CommandText = "INSERT INTO [frutas] ([nombre],[peso],[precio])" + " VALUES (@nombre, @peso, @precio)";
                    comando.Parameters.AddWithValue("@nombre", frm._banana.Nombre);
                    comando.Parameters.AddWithValue("@peso", frm._banana.Peso);
                    comando.Parameters.AddWithValue("@precio", frm.c_bananas.PrecioTotal / frm.c_bananas.Elementos.Count);

                    filas += comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                    comando.CommandText = "INSERT INTO [frutas] ([nombre],[peso],[precio])" + " VALUES (@nombre, @peso, @precio)";
                    comando.Parameters.AddWithValue("@nombre", frm._melocoton.Nombre);
                    comando.Parameters.AddWithValue("@peso", frm._melocoton.Peso);
                    comando.Parameters.AddWithValue("@precio", frm.c_melocotones.PrecioTotal / frm.c_melocotones.Elementos.Count);

                    filas += comando.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        retorno = true;
                    }

                }

            }
            catch (Exception e1)
            {

                MessageBox.Show(e1.Message);
            }

            return retorno;
        }
        
        
        /// <summary>
        /// Se Crea un hilo que invocara a todos los manejadores de eventos (de los botones)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPunto9_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(this.Eventos);

            t.Start();
        }

        /// <summary>
        /// Se invoca a todos los manejadores de eventos, se asocia con el punto9 con elhilo creado
        /// </summary>
        public void Eventos()
        {
            Thread.Sleep(1000);

            MessageBox.Show("Opcion Uno: ");

            this.btnPunto1_Click(new object(), new EventArgs());

            MessageBox.Show("Obpcion Dos: ");

            this.btnPunto2_Click(new object(), new EventArgs());

            MessageBox.Show("Opcion Tres: ");

            this.btnPunto3_Click(new object(), new EventArgs());

            MessageBox.Show("Opcion Cuatro: ");

            this.btnPunto4_Click(new object(), new EventArgs());

            MessageBox.Show("Opcion Cinco: ");

            this.btnPunto5_Click(new object(), new EventArgs());

            MessageBox.Show("Opcion Seis: ");

            this.btnPunto6_Click(new object(), new EventArgs());

            MessageBox.Show("Opcion Siete: ");

            this.btnPunto7_Click(new object(), new EventArgs());

            MessageBox.Show("Opcion Ocho: ");

            this.btnPunto8_Click(new object(), new EventArgs());
            
        }

    }
}
