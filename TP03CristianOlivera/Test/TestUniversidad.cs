using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using ClasesInstanciables;
using Archivos;

namespace TestUnitarioEntidades
{
    [TestClass]
    public class EntidadesTest
    {
        

        /// <summary>
        ///Test unitario que lanza una excepcion de tipo AlumnoRepetidoException al intentar agregar dos alumnos iguales a la misma universidad.
        /// El metodo falla si permite que se agregue el alumno repetido, o si la excepcion que lanza es de un tipo distinto a AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void VerificarAlumnoRepetidoException_OK()
        {
            //ARRANGE
            
            Alumno alumno = new Alumno(1, "Mario", "garza", "5000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            //
            Alumno alumnoRepetido = new Alumno(1, "Mario", "garza", "5000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Universidad universidad = new Universidad();

            try
            {
                //ACT
                universidad += alumno;
                universidad += alumnoRepetido;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
            }
        }
        /// <summary>
        /// Test unitario qye leera un archivo de texto existente al pasarle el path del mismo al metodo Leer() de la clase Texto
        /// Si no se puede leer, el metodo falla el Test
        /// </summary>
        [TestMethod]
        public void VerificarLeerArchivoTexto_OK()
        {
            //ARRANGE
            Texto txt = new Texto();

            string datos = "Este archivo se genero al probar el metodo VerificarLeerArchivoTexto_OK() del proyecto TestUnitarioEntidades.";

            string datosLeidos;

            string path = "LeerArchivoDeTextoTest.txt";

            //ACT
            txt.Guardar(path, datos);

            try
            {
                txt.Leer(path, out datosLeidos);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
        /// <summary>
        ///Test unitario que verifica que se guarda un archivo de texto al pasarle un path para crearlo y/o guardarlo a traves del metodo Guardar() de la clase Texto
        /// Si se lanza la excepcion o el archivo no existe luego de ejecutar el metodo Guardar(), el metodo falla el Test 
        /// </summary>
        [TestMethod]
        public void VerificarGuardarArchivoTexto_OK()
        {
            //ARRANGE
            Texto txt = new Texto();

            string datos = "Este archivo se ha generado al probar el metodo VerificarGuardarArchivoTexto_OK() del proyecto TestUnitarioEntidades.";

            string archivo = "GuardarArchivoDeTextoTest.txt";

            //ACT
            try
            {
                txt.Guardar(archivo, datos);

                if (!File.Exists(archivo))
                {
                    Assert.Fail();
                }//
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
        /// <summary>
        /// Test unitario que agrega dos alumnos con diferente id a la misma universidad.
        /// El metodo falla si es que se lanza una excepcion de tipo AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        public void VerificarAlumnoRepetidoException_Fail()
        {
            
            //arrange
            Alumno a1 = new Alumno(1, "Gabriel", "Sosa", "15000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Alumno a2 = new Alumno(2, "Gabriel", "Sosa", "15000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Universidad universidad = new Universidad();

            try
            {
                //ACT
                universidad += a1;
                universidad += a2;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(AlumnoRepetidoException))
                {
                    //ASSERT
                    Assert.Fail();
                }
            }
        }

        

        /// <summary>
        ///Test unitario que lanza una excepcion de tipo ArchivosException al pasarle un path de un archivo de texto inexistente al metodo Leer() de la clase Texto
        /// Si no se lanza la excepcion, el metodo falla el Test
        /// </summary>
        [TestMethod]
        public void VerificarLeerArchivoTexto_Fail()
        {
            //ARRANGE
            Texto txt = new Texto();

            string datos;

            string path = "ArchivoInexistente.txt";
            //
            //ACT
            try
            {//

                txt.Leer(path, out datos);

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArchivosException));
            }
        }

        

        /// <summary>
        ///Test unitario que lanza una excepcion de tipo ArchivosException al pasarle un path nulo para crear un archivo con el metodo Guardar() de la clase Texto
        /// Si no se lanza la excepcion, el metodo falla el Test
        /// </summary>
        [TestMethod]
        public void VerificarGuardarArchivoTexto_Fail()
        {
            //ARRANGE
            Texto txt = new Texto();
            //
            string datos = "Este archivo se ha generado al probar el metodo VerificarGuardarArchivoTexto_Fail() del proyecto TestUnitarioEntidades";

            string archivo = null;

            //ACT
            try
            {//
                txt.Guardar(archivo, datos);

                Assert.Fail();

            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArchivosException));
            }
        }
        /// <summary>
        /// Test unitario que verifica que se creen las listas de los atributos de una instancia de tipo Universidad
        /// El metodo falla si alguna de las listas tienen valor nulo
        /// </summary>
        [TestMethod]
        public void VerificarListaAlumnoUniversidad_OK()
        {
            //ARRANGE
            Universidad universidad = new Universidad();

            //ACT
            if (universidad.Alumnos == null || universidad.Instructores == null || universidad.Jornadas == null)
            {

                //ASSERT
                Assert.Fail();
            }
        }
    }
}