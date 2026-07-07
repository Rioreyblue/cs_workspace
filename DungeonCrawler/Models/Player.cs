using System;
using System.Collections.Generic;

namespace DungeonCrawler.Models;

public class Player
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Attack { get; set; }
    public Position CurrentPosition { get; set; }
    public List<string> Inventory { get; set; } = new();

    public Player(string name, int hp, int attack)
    {
        Name = name;
        HP = hp;
        MaxHP = hp;
        Attack = attack;
        CurrentPosition = new Position(0, 0); // Start at origin
    }

    public bool IsDead => HP <= 0;

    public void Move(Standard.Direction direction)
    {
        CurrentPosition = direction switch
        {
            Standard.Direction.North => CurrentPosition with { Y = CurrentPosition.Y + 1 },
            Standard.Direction.South => CurrentPosition with { Y = CurrentPosition.Y - 1 },
            Standard.Direction.East => CurrentPosition with { X = CurrentPosition.X + 1 },
            Standard.Direction.West => CurrentPosition with { X = CurrentPosition.X - 1 },
            _ => CurrentPosition
        };
    }
}