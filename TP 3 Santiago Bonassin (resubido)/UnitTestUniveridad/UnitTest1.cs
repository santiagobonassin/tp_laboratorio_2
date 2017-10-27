using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;

namespace UnitTestUniveridad
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerificarDniInvalido()
        {
            try
            {
                Alumno unAlumno = new Alumno(1, "Carlos", "Rodriguez", "41564568", Persona.Enacionalidad.Extranjero, Universidad.EClases.Programacion);
            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
        [TestMethod]
        public void VerificarAlumnoRepetido()
        {
            try
            {
                Universidad unaUniversidad = new Universidad();
                Alumno unAlumno = new Alumno(1, "Carlos", "Rodriguez", "41564568", Persona.Enacionalidad.Argentino, Universidad.EClases.SPD);
                unaUniversidad += unAlumno;
                unaUniversidad += unAlumno;
            }
            catch (AlumnoRepetidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
        [TestMethod]
        public void VerificarNull()
        {
            Universidad unaUniversidad = new Universidad();
            Assert.IsNotNull(unaUniversidad.Alumnos);
            Assert.IsNotNull(unaUniversidad.Instructores);
        }
        [TestMethod]
        public void ValidarSiEsNumero()
        {
            Alumno unAlumno = new Alumno(1, "Carlos", "Rodriguez", "41564568", Persona.Enacionalidad.Argentino, Universidad.EClases.Legislacion);
            Assert.IsInstanceOfType(unAlumno.DNI, typeof(int));
        }
    }
}
