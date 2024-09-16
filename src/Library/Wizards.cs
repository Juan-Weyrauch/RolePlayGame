using System.Collections;

namespace Library{ 

public class Wizard
{
    private string name;
    private int life;
    private int magia; 
    private int initialLife;
    private ArrayList items = new ArrayList();
    private SpellBook spellBook;

    public Wizard(string name, int life, SpellBook spellBook, int magia)
    {
        this.name = name;
        this.life = life;
        this.initialLife = life;
        this.spellBook = spellBook;
        this.magia = magia;
    }

    public void AddItem(Item item)
    {
        if (item != null)
        {
            this.items.Add(item);
        }
        else
        {
            Console.WriteLine("Ese item no existe");
        }
    }

    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            this.items.Remove(item);
        }
        else
        {
            Console.WriteLine("Ese item no existe");
        }
    }

    public int TotalDamage()
    {
        int totalatk = 0;
        foreach (Item item in this.items)
        {
            totalatk += item.AttackValue;
        }

        totalatk += totalatk/10*magia; // Se implementa una manera de aumentar el damage total de mago en base a su cantidad de magia, como implica la letra.
        return totalatk;
    }

    public int TotalDefense()
    {
        int totaldef = 0;
        foreach (Item item in this.items)
        {
            totaldef += item.DefenseValue;
        }
        return totaldef;
    }
    /*
    Utiliza el concepto de Sobrecarga de metodos, para poder satisfacer las necesidades, siendo target cualquiera de los tres tipos
    se pone en practica un metodo publico establecido en cada clase para obtener el valor del nombre.
    */
    public void Attack(Wizard target) // Permite atacar a el mago.
    {
        int damage = this.TotalDamage();
        target.ReceiveDamage(damage);
        Console.WriteLine($"{this.name} ataca a {target.GetName()} y causa {damage} de daño.");
        
    }
    public void Attack(Dwarf target) // Permite atacar a el Enano.
    {
        int damage = this.TotalDamage();
        target.ReceiveDamage(damage);
        Console.WriteLine($"{this.name} ataca a {target.GetName()} y causa {damage} de daño.");
    }
    public void Attack(Elf target) // Permite atacar a el Elfo.
    {
        int damage = this.TotalDamage();
        target.ReceiveDamage(damage);
        Console.WriteLine($"{this.name} ataca a {target.GetName()} y causa {damage} de daño.");
    }

    public void UseSpell(Spell spell, Wizard target) // Permite utilizar los hechizos almacenados en el libro correspondiente a ese objeto.
    {
        if (this.spellBook.ContainsSpell(spell))
        {
            int damage = spell.AttackValue;
            Console.WriteLine($"{this.name} usa {spell.Name} en {target.GetName()} y causa {damage} de daño.");
            target.ReceiveDamage(damage);
        }
        else
        {
            Console.WriteLine($"{this.name} no tiene el hechizo {spell.Name}.");
        }
    }
    
    public void UseSpell(Spell spell, Dwarf target) // Permite utilizar los hechizos almacenados en el libro correspondiente a ese objeto.
    {
        if (this.spellBook.ContainsSpell(spell))
        {
            int damage = spell.AttackValue;
            Console.WriteLine($"{this.name} usa {spell.Name} en {target.GetName()} y causa {damage} de daño.");
            target.ReceiveDamage(damage);
        }
        else
        {
            Console.WriteLine($"{this.name} no tiene el hechizo {spell.Name}.");
        }
    }
    
    public void UseSpell(Spell spell, Elf target) // Permite utilizar los hechizos almacenados en el libro correspondiente a ese objeto.
    {
        if (this.spellBook.ContainsSpell(spell))
        {
            int damage = spell.AttackValue;
            Console.WriteLine($"{this.name} usa {spell.Name} en {target.GetName()} y causa {damage} de daño.");
            target.ReceiveDamage(damage);
        }
        else
        {
            Console.WriteLine($"{this.name} no tiene el hechizo {spell.Name}.");
        }
    }

    public void ReceiveDamage(int damage) // Permite recibir el damage entrante.
    {
        this.life -= damage;
        if (this.life < 0) this.life = 0;
        Console.WriteLine($"{this.name}  life restante: {this.life}");
    }

    public void Heal() // Se utiliza para poder curar a este personaje a el maximo de vida.
    {
        this.life = this.initialLife;
        Console.WriteLine($"{this.name} ha sido curado. life restaurada a: {this.life}");
    }

    public string GetInfo() // Metodo que permite obtener toda la informacion del personaje, en este caso se trata del Wizzard(mago).
    {
        string info = $"Nombre: {this.name}, life: {this.life}\nItems:\n";
        foreach (Item item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.AttackValue}, Defensa: {item.DefenseValue})\n";
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";
        info += $"Total Defensa: {this.TotalDefense()}\n";
        info += $"Magia: {this.magia}\n";
        info += this.spellBook.GetSpellsInfo();
        
        return info;
    }
    public string GetName()
    {
        return this.name;
    }
    public void Study() // Metodo que permite incrementar en uno la magia del mago.
    {
        this.magia += 1;
    }

    public int GetLife(){
        return life;
    }
}

}