using NUnit.Framework;
using Library; 
using System.Collections;

namespace LibraryTests
{
    public class ElfTests
    {
        private Elf elfo;
        private Elf targetElfo;
        private Item sword;
        private Item shield;

        [SetUp]
        public void Setup()
        {
            // Inicializar objetos
            elfo = new Elf("Elfo1", 100);
            targetElfo = new Elf("Elfo2", 100);
            sword = new Item("Espada", 20, 0); // Attaque: 20, Defensa: 0
            shield = new Item("Escudo", 0, 20); // Attaque: 0, Defensa: 20
        }

        [Test]
        public void AgregarItemValido()
        {
            
            elfo.AddItem(sword);
            elfo.AddItem(shield);

            
            Assert.That(elfo.TotalDamage(), Is.EqualTo(20));
            Assert.That(elfo.TotalDefense(), Is.EqualTo(20));
        }

        [Test]
        public void RemoverItemBajaAtaque()
        {
            
            elfo.AddItem(sword);
            elfo.AddItem(shield);

            
            elfo.RemoveItem(sword);

            
            Assert.That(elfo.TotalDamage(), Is.EqualTo(0));
            Assert.That(elfo.TotalDefense(), Is.EqualTo(20));
        }

        [Test]
        public void AtaqueReduceDañoDeTarget()
        {
            elfo.AddItem(sword);
            int initialLife = targetElfo.GetLife();

            elfo.Attack(targetElfo);

            Assert.That(targetElfo.GetLife(), Is.EqualTo(initialLife - sword.AttackValue));
        }

        [Test]
        public void RecibirDañoReduceVida()
        {
            elfo.ReceiveDamage(30);

            Assert.That(elfo.GetLife(), Is.EqualTo(70));
        }

        [Test]
        public void RecibirDaño_NoDebeSerMenorQueCero()
        {
            elfo.ReceiveDamage(150);

            Assert.That(elfo.GetLife(), Is.EqualTo(0));
        }

        [Test]
        public void Curar_DebeRecuperarLaVidaInicial()
        {
            elfo.ReceiveDamage(50);

            elfo.Heal();

            Assert.That(elfo.GetLife(), Is.EqualTo(100));
        }

        [Test]
        public void GetInfo_DebeDevolverLaInformacion()
        {
            elfo.AddItem(sword);
            elfo.AddItem(shield);

            string info = elfo.GetInfo();

            StringAssert.Contains("Nombre: Elfo1", info);
            StringAssert.Contains("Vida: 100", info);
            StringAssert.Contains("Espada", info);
            StringAssert.Contains("Escudo", info);
            StringAssert.Contains("Total Ataque: 20", info);
            StringAssert.Contains("Total Defensa: 20", info);
        }
    }
}
