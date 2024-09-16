using NUnit.Framework;
using Library; 
using System.Collections;

namespace LibraryTests
{
    public class SpellTests{
        private Spell hechizo;

        [SetUp]
        public void Setup(){
            //Inicializar el hechizo
            hechizo = new Spell ("AbadaKadabrabro", 10);
        }

        [Test]
        public void ObtenerNombre(){
             Assert.That(hechizo.Name, Is.EqualTo("AbadaKadabrabro"));
        }

        [Test]
        public void EstablecerNombre(){
            hechizo.Name = "PataDeCabra";
            Assert.That(hechizo.Name, Is.EqualTo("PataDeCabra"));
        }

        [Test]
        public void ObtenerValorDeAtaque(){
            Assert.That(hechizo.AttackValue, Is.EqualTo(10));
        }

        [Test]
        public void EstablecerValorAtaque_ValorCorrecto()
        {
            hechizo.AttackValue = 10000000; //re op
            Assert.That(hechizo.AttackValue, Is.EqualTo(10000000));
        }
    }
}