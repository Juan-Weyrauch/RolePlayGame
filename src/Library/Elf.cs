using System.Collections;

namespace Library{ 
public class Elf
{
    private string name;
    private int life;
    private int initialLife;
    private ArrayList items = new ArrayList();

    public Elf(string name, int life)
    {
        this.name = name;
        this.life = life;
        this.initialLife = life;
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

    //Creado para los tests
    public int GetLife(){
        return life;
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

    public void ReceiveDamage(int damage)
    {
        this.life -= damage;
        if (this.life < 0) this.life = 0;
        Console.WriteLine($"{this.name} recibe {damage} de daño. Vida restante: {this.life}");
    }

    public void Heal()
    {
        this.life = this.initialLife;
        Console.WriteLine($"{this.name} ha sido curado. Vida restaurada a: {this.life}");
    }

    public string GetInfo()
    {
        string info = $"Nombre: {this.name}, Vida: {this.life}\nItems:\n";
        foreach (Item item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.AttackValue}, Defensa: {item.DefenseValue})\n";
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";
        info += $"Total Defensa: {this.TotalDefense()}\n";
        return info;
    }
    public string GetName()
    {
        return this.name;
    }
}
}