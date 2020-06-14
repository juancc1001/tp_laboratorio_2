using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoExcepcion : Exception
    {

        public DniInvalidoExcepcion() : this("ERROR, formato de DNI invalido", new Exception()) { }

        public DniInvalidoExcepcion(Exception e) : this("ERROR, formato de DNI invalido", e) { }

        public DniInvalidoExcepcion(string message) : this(message, new Exception()) { }

        public DniInvalidoExcepcion(string message, Exception e) : base(message, e) { }

    }
}
