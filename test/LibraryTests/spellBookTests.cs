using NUnit.Framework;
using Library; 
using System.Collections;

namespace LibraryTests
{
    public class SpellBookTests
    {
        private SpellBook spellBook;
        private Spell spell1;
        private Spell spell2;

        [SetUp]
        public void Setup()
        {
            spellBook = new SpellBook();
            spell1 = new Spell("abadakedabra", 50);
            spell2 = new Spell("Wingardium Leviosa", 30);
        }

        [Test]
        public void AgregarHechizo()
        {
            spellBook.AddSpell(spell1);
            Assert.IsTrue(spellBook.ContainsSpell(spell1));
        }

        [Test]
        public void BorrarHechizo()
        {
            spellBook.AddSpell(spell1);
            spellBook.RemoveSpell(spell1);
            Assert.IsFalse(spellBook.ContainsSpell(spell1));
        }

        [Test]
        public void ContieneHechizo()
        {
            spellBook.AddSpell(spell1);
            Assert.IsTrue(spellBook.ContainsSpell(spell1));
            Assert.IsFalse(spellBook.ContainsSpell(spell2));
        }

        [Test]
        public void ObtenerInfoHechizos()
        {
            spellBook.AddSpell(spell1);
            spellBook.AddSpell(spell2);
            string expectedInfo = "Hechizos:\n- abadakedabra (Ataque: 50)\n- Wingardium Leviosa (Ataque: 30)\n";
            Assert.That(spellBook.GetSpellsInfo(), Is.EqualTo(expectedInfo));
        }
    }
}
