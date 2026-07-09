using System;
using DungeonCrawler.Models;
using DungeonCrawler.Standard;

namespace DungeonCrawler.Core;

public class GameEngine
{
    private readonly GameMap _map;
    private readonly Player _player;
    private readonly Random _random = new();
    private bool _isRunning = true;

    public GameEngine()
    {
        _map = new GameMap();
        _player = new Player("Hero", 100, 12);
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the C# Text Dungeon Crawler!");
        Console.WriteLine("Commands: N (North), S (South), E (East), W (West), I (Inventory), Q (Quit)\n");

        while (_isRunning && !_player.IsDead)
        {
            Room? currentRoom = _map.GetRoom(_player.CurrentPosition);
            
            if (currentRoom == null)
            {
                Console.WriteLine("You are trapped in a void. This shouldn't happen!");
                break;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n--- [Location: X:{_player.CurrentPosition.X}, Y:{_player.CurrentPosition.Y}] ---");
            Console.ResetColor();
            Console.WriteLine(currentRoom.Description);

            // Item pickup phase
            if (currentRoom.Item != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"You found a {currentRoom.Item}! It has been added to your inventory.");
                Console.ResetColor();
                _player.Inventory.Add(currentRoom.Item);
                currentRoom.Item = null; // Remove item from room
            }

            // Combat trigger phase
            if (currentRoom.RoomEnemy != null)
            {
                HandleCombat(currentRoom.RoomEnemy);
                if (_player.IsDead) break;
            }

            // Command Processing
            ProcessInput();
        }

        if (_player.IsDead)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou have perished in the dungeon... Game Over.");
            Console.ResetColor();
        }
    }

    private void ProcessInput()
    {
        Console.Write("\nWhat will you do? > ");
        string? input = Console.ReadLine()?.ToUpper().Trim();

        switch (input)
        {
            case "N": TryMove(Direction.North); break;
            case "S": TryMove(Direction.South); break;
            case "E": TryMove(Direction.East); break;
            case "W": TryMove(Direction.West); break;
            case "I": ShowInventory(); break;
            case "Q": _isRunning = false; Console.WriteLine("Thanks for playing!"); break;
            default: Console.WriteLine("Invalid command!"); break;
        }
    }

    private void TryMove(Direction dir)
    {
        // Peek ahead to see if a room exists
        Position nextPos = dir switch
        {
            Direction.North => _player.CurrentPosition with { Y = _player.CurrentPosition.Y + 1 },
            Direction.South => _player.CurrentPosition with { Y = _player.CurrentPosition.Y - 1 },
            Direction.East => _player.CurrentPosition with { X = _player.CurrentPosition.X + 1 },
            Direction.West => _player.CurrentPosition with { X = _player.CurrentPosition.X - 1 },
            _ => _player.CurrentPosition
        };

        if (_map.GetRoom(nextPos) != null)
        {
            _player.Move(dir);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Ouch! You hit a solid stone wall. You cannot go that way.");
            Console.ResetColor();
        }
    }

    private void ShowInventory()
    {
        Console.WriteLine("\n--- Inventory ---");
        if (_player.Inventory.Count == 0) Console.WriteLine("Empty.");
        foreach (var item in _player.Inventory) Console.WriteLine($"- {item}");
    }

    private void HandleCombat(Enemy enemy)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n⚠️ A wild {enemy.Name} blocks your path! (HP: {enemy.HP}, ATK: {enemy.Attack})");
        Console.ResetColor();

        while (!enemy.IsDead && !_player.IsDead)
        {
            Console.WriteLine("Press [Enter] to attack!");
            Console.ReadLine();

            // Player Turn with randomness
            int playerDmg = _player.Attack + _random.Next(-2, 4); // attack variation
            playerDmg = Math.Max(1, playerDmg); // clear negative damage
            enemy.HP -= playerDmg;
            Console.WriteLine($"You swing and hit the {enemy.Name} for {playerDmg} damage!");

            if (enemy.IsDead)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You defeated the {enemy.Name}!");
                Console.ResetColor();
                break;
            }

            // Enemy Turn (Basic AI logic: always attack if alive)
            int enemyDmg = enemy.Attack + _random.Next(-1, 3);
            enemyDmg = Math.Max(1, enemyDmg);
            _player.HP -= enemyDmg;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"The {enemy.Name} strikes back for {enemyDmg} damage! (Your HP: {Math.Max(0, _player.HP)}/{_player.MaxHP})");
            Console.ResetColor();
        }
    }
}