using System.Collections;

namespace Library{ 
public class SpellBook
{
    private ArrayList spells = new ArrayList(); // Crea una array para contener los hechizos del libro.

    public void AddSpell(Spell spell) // Permite guardar los hechizos que se requieran.
    {
        if (spell != null)
        {
            this.spells.Add(spell);
        }
        else
        {
            Console.WriteLine("Ese hechizo no existe");
        }
    }

    public void RemoveSpell(Spell spell) // Permite borrar hechizos del libro.
    {
        if (spell != null)
        {
            this.spells.Remove(spell);
        }
        else
        {
            Console.WriteLine("Ese hechizo no existe");
        }
    }

    public bool ContainsSpell(Spell spell) // Indica si un hechizo se encuentra dentro de un libro. Funciona unicamente con objetos de la clase Spell.
    {
        return this.spells.Contains(spell);
    }

    public string GetSpellsInfo() // Metodo que permite obtener toda la informacion existente de la cantidad de hechizos y su respectiva informacion dentro de un libro.    
    {
        string info = "Hechizos:\n";
        foreach (Spell spell in this.spells)
        {
            info += $"- {spell.Name} (Ataque: {spell.AttackValue})\n";
        }
        return info;
    }
}
}