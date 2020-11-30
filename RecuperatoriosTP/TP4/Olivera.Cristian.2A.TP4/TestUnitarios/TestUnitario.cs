using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using WindowsForms;
using System.Data.SqlClient;
using System.Data;


namespace TestUnitarios
{
    [TestClass]
    public class TestUnitarios
    {
        /// <summary>
        /// Test si los productos estan iguales
        /// </summary>
        [TestMethod]
        public void ComprobarFuncionamientoProductoIgualProducto()
        {
            bool iguales;
            SmartPhone s1 = new SmartPhone(1, "Galaxy Core", 240, "Apple", ESistemaOperativo.iOS, EMemoria.GB32);
            SmartPhone s2 = new SmartPhone(1, "Galaxy Plus", 220, "Samsung", ESistemaOperativo.Android, EMemoria.GB16);

            iguales = s1 == s2;

            Assert.IsTrue(iguales);
        }

        /// <summary>
        /// Test si la serializacion se realiza correctamente
        /// </summary>
        [TestMethod]
        public void ComprobarSerializacion()
        {
            Vendedora v = new Vendedora();

            Assert.IsTrue(Vendedora.GuardarXml("SmartPhone.xml", v));
        }

        /// <summary>
        ///Test si la conexion con la base de datos se realiza correctamente
        /// </summary>
        [TestMethod]
        public void ComprobarConexionBaseDeDatos()
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexionBD);

            conexion.Open();

            Assert.IsTrue(conexion.State == ConnectionState.Open);
        }
    }
}
