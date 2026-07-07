namespace DungeonCrawler.Models;

public class Enemy
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Attack { get; set; }

    public Enemy(string name, int hp, int attack)
    {
        Name = name;
        HP = hp;
        MaxHP = hp;
        Attack = attack;
    }

    public bool IsDead => HP <= 0;
}