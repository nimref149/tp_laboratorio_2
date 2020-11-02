﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor que inicializa atributo message de clase base Exception
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.") 
        {
        
        }

    }
}
