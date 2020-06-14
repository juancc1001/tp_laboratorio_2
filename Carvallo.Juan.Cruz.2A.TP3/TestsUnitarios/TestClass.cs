using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Archivos;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            Alumno alumnoPrueba = new Alumno(1, "Nombre", "Apellido", "10000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoExcepcion))]
        public void TestDniInvalidoException()
        {
            Alumno alumnoPrueba = new Alumno(1, "Nombre", "Apellido", "10000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio); 

            alumnoPrueba.StringToDNI = "dniinvalido";

        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException_1()
        {
            Universidad universidad = new Universidad();
            Alumno alumno1 = new Alumno(1, "Nombre", "Apellido", "10000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio); 
            Alumno alumno2 = new Alumno(2, "Nombre", "Apellido", "10000002", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno3 = new Alumno(1, "Nombre", "Apellido", "10000003", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            universidad += alumno1;
            universidad += alumno2;
            universidad += alumno3;
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException_2()
        {
            Universidad universidad = new Universidad();
            Alumno alumno1 = new Alumno(1, "Nombre", "Apellido", "10000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(2, "Nombre", "Apellido", "10000002", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno3 = new Alumno(3, "Nombre", "Apellido", "10000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            universidad += alumno1;
            universidad += alumno2;
            universidad += alumno3;
        }

        [TestMethod]
        public void TestColeccionesJornada_ok()
        {
            Jornada jornadaPrueba = new Jornada(Universidad.EClases.Laboratorio, new Profesor(1, "Juan", "Perez", "10000000", Persona.ENacionalidad.Argentino));

            Assert.IsNotNull(jornadaPrueba.Alumnos);
        }


    }
}
