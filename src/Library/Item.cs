using System;

namespace Library{ 

public class Item // Se crea la clase Item, donde se setean los valores 
{
    private string name; // Usando este patron de Get & Set se mantiene el atributo privado.
    public string Name 
    {
        get { return name; }
        set { name = value; }
    }

    private int attackValue;
    public int AttackValue
    {
        get { return attackValue; }
        set { attackValue = value; }
    }

    private int defenseValue;
    public int DefenseValue {
        get { return defenseValue; }
        set { defenseValue = value; }
    }

    public Item(string name, int attackValue, int defenseValue) //Metodo constructor que se logra a traves de sobrecarga; de la clase item.
    {
        this.Name = name;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
    }
}
}