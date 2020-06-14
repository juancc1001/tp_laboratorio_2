using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException) 
            : base("La serealizacion falló por las siguientes causas: " + innerException.Message, innerException) { }
    }
}
