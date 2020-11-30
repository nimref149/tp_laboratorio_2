using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Entidades
{
    public class BaseDeDatos
    {
        private SqlConnection conexion;
        private DataTable tabla;
        private SqlDataAdapter dataAdapter;

        public BaseDeDatos()
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
        }

        /// <summary>
        /// Funcion que se configura el data table.
        /// </summary>
        public DataTable ConfigurarDataTable(string tabla)
        {
            this.tabla = new DataTable(tabla);

            this.tabla.Columns.Add("idVenta", typeof(int));

            this.tabla.PrimaryKey = new DataColumn[] { this.tabla.Columns[0] }; //AGREGO LA COLUMNA COMO PRIMARY KEY

            this.tabla.Columns[0].AutoIncrement = true; //HAGO LA COLUMNA AUTOINCREMENTAL   
            this.tabla.Columns[0].AutoIncrementSeed = 1;
            this.tabla.Columns[0].AutoIncrementStep = 1;

            return this.tabla;
        }

        /// <summary>
        ///Funcion que se configura el data adapter, la conexion a la base de datos y los comandos de insercion y seleccion
        /// </summary>
        /// <returns>Retorna true si se pudo configurar, caso contrario false</returns>
        public SqlDataAdapter ConfigurarDataAdapter(string tabla)
        {
            this.dataAdapter = new SqlDataAdapter();
            try
            {
                if (tabla == "smartPhone")
                {
                    this.dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM [BaseTP4].[dbo].[SmartPhone] ", this.conexion);
                    this.dataAdapter.InsertCommand = new SqlCommand("INSERT INTO [BaseTP4].[dbo].[SmartPhone] (producto, marca, sistemaOperativo, memoria, precio) VALUES (@producto, @marca, @sistemaOperativo, @memoria, @precio)", this.conexion);
                    this.dataAdapter.InsertCommand.Parameters.Add("@sistemaOperativo", SqlDbType.VarChar, 50, "sistemaOperativo");
                    this.dataAdapter.InsertCommand.Parameters.Add("@memoria", SqlDbType.Char, 50, "memoria");
                    this.dataAdapter.InsertCommand.Parameters.Add("@producto", SqlDbType.VarChar, 50, "producto");
                    this.dataAdapter.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                    this.dataAdapter.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                }
                else if (tabla == "pantalla")
                {
                    this.dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM [BaseTP4].[dbo].[pantalla] ", this.conexion);
                    this.dataAdapter.InsertCommand = new SqlCommand("INSERT INTO [BaseTP4].[dbo].[pantalla] (producto, marca, resolucion, pulgadas, precio) VALUES (@producto, @marca, @resolucion, @pulgadas, @precio)", this.conexion);
                    this.dataAdapter.InsertCommand.Parameters.Add("@resolucion", SqlDbType.VarChar, 50, "resolucion");
                    this.dataAdapter.InsertCommand.Parameters.Add("@pulgadas", SqlDbType.Int, 50, "pulgadas");
                    this.dataAdapter.InsertCommand.Parameters.Add("@producto", SqlDbType.VarChar, 50, "producto");
                    this.dataAdapter.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 50, "marca");
                    this.dataAdapter.InsertCommand.Parameters.Add("@precio", SqlDbType.Float, 10, "precio");
                }
                else
                {
                    this.dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM [BaseTP4].[dbo].[historialVentas] ", this.conexion);
                    this.dataAdapter.UpdateCommand = new SqlCommand("UPDATE [BaseTP4].[dbo].[historialVentas] SET cantidadTotalVentas=@cantidad", this.conexion);
                    this.dataAdapter.UpdateCommand.Parameters.Add("@cantidad", SqlDbType.Int, 50, "cantidadTotalVentas");
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return this.dataAdapter;
        }

        /// <summary>
        ///Funcion que modifica las propiedades del datagridview
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public DataGridView ConfigurarGrilla(DataGridView dataGridView)
        {
            dataGridView.RowsDefaultCellStyle.BackColor = Color.Teal;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Teal;
            dataGridView.BackgroundColor = Color.LightSalmon;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.GridColor = Color.LightSalmon;
            dataGridView.ReadOnly = false;
            dataGridView.MultiSelect = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView.RowsDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AllowUserToAddRows = false;

            return dataGridView;
        }
    }
}
