using NUnit.Framework;
using System.Collections;
using Library; 


namespace LibraryTests
{
    public class DwarfTests
    {
        private Dwarf dwarf;
        private Dwarf targetDwarf;
        private Item sword;
        private Item shield;

        [SetUp]
        public void Setup()
        {
            // Inicializar objetos
            dwarf = new Dwarf("Enano1", 100);
            targetDwarf = new Dwarf("Enano2", 100);
            sword = new Item("Espada", 20, 0); // Attaque: 20, Defensa: 0
            shield = new Item("Escudo", 0, 20); // Attaque: 0, Defensa: 20
        }

        [Test]
        public void AgregarItemValido()
        {
            
            dwarf.AddItem(sword);
            dwarf.AddItem(shield);

            
            Assert.That(dwarf.TotalDamage(), Is.EqualTo(20));
            Assert.That(dwarf.TotalDefense(), Is.EqualTo(20));
        }

        [Test]
        public void RemoverItemBajaAtaque()
        {
            
            dwarf.AddItem(sword);
            dwarf.AddItem(shield);

            
            dwarf.RemoveItem(sword);

            
            Assert.That(dwarf.TotalDamage(), Is.EqualTo(0));
            Assert.That(dwarf.TotalDefense(), Is.EqualTo(20));
        }

        [Test]
        public void AtaqueReduceDañoDeTarget()
        {
            dwarf.AddItem(sword);
            int initialLife = targetDwarf.GetLife();

            dwarf.Attack(targetDwarf);

            Assert.That(targetDwarf.GetLife(), Is.EqualTo(initialLife - sword.AttackValue));
        }

        [Test]
        public void RecibirDañoReduceVida()
        {
            dwarf.ReceiveDamage(30);

            Assert.That(dwarf.GetLife(), Is.EqualTo(70));
        }

        [Test]
        public void RecibirDaño_NoDebeSerMenorQueCero()
        {
            dwarf.ReceiveDamage(150);

            Assert.That(dwarf.GetLife(), Is.EqualTo(0));
        }

        [Test]
        public void Curar_DebeRecuperarLaVidaInicial()
        {
            dwarf.ReceiveDamage(50);

            dwarf.Heal();

            Assert.That(dwarf.GetLife(), Is.EqualTo(100));
        }

        [Test]
        public void GetInfo_DebeDevolverLaInformacion()
        {
            dwarf.AddItem(sword);
            dwarf.AddItem(shield);

            string info = dwarf.GetInfo();

            StringAssert.Contains("Nombre: Enano1", info);
            StringAssert.Contains("Vida: 100", info);
            StringAssert.Contains("Espada", info);
            StringAssert.Contains("Escudo", info);
            StringAssert.Contains("Total Ataque: 20", info);
            StringAssert.Contains("Total Defensa: 20", info);
        }
    }
}
