using NUnit.Framework;
using Library; 
using System.Collections;

namespace LibraryTests
{
    public class ItemTests
    {
        private Item item;

        [SetUp]
        public void Setup()
        {
            // Inicializar item
            item = new Item ("Espada", 15, 0);
        }

        [Test]
        public void ObtenerNombre() //Obtener el nombre del item
        {
            Assert.That(item.Name, Is.EqualTo("Espada"));
        }

        [Test]
        public void EstablecerNombre() //Establecer el nombre del item (es mutable)
        {
            item.Name = "Hacha";
            Assert.That(item.Name, Is.EqualTo("Hacha"));
        }

        [Test]
        public void ObtenerValorAtaque() //Obtener el valor de ataque del item
        {
            Assert.That(item.AttackValue, Is.EqualTo(15));
        }

        [Test]
        public void EstablecerValorAtaque() //Establecer el valor de ataque del item
        {
            item.AttackValue = 20;
            Assert.That(item.AttackValue, Is.EqualTo(20));
        }

        [Test]
        public void ObtenerValorDeDefensa() //Obtener el valor de defensa del iten
        {
            Assert.That(item.DefenseValue, Is.EqualTo(0));
        }

        [Test]
        public void EstablecerValorDeDefensa() //Estab;ecer el valor de defensa del item
        {
            item.DefenseValue = 10;
            Assert.That(item.DefenseValue, Is.EqualTo(10));
        }
    }
}