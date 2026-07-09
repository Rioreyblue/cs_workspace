using System.Collections.Generic;
using DungeonCrawler.Models;

namespace DungeonCrawler.Core;

public class GameMap
{
    private readonly Dictionary<Position, Room> _rooms = new();

    public GameMap()
    {
        GenerateDungeon();
    }

    private void GenerateDungeon()
    {
        // Populate our grid with rooms
        _rooms.Add(new Position(0, 0), new Room("You are in a damp, dimly lit entrance room. The air is stale. There is a doorway to the North."));
        _rooms.Add(new Position(0, 1), new Room("An armory room. Rusted swords line the walls.", "Iron Sword"));
        _rooms.Add(new Position(1, 1), new Room("The Guard Room. A foul stench fills the air.", null, new Enemy("Goblin Sentry", 25, 5)));
        _rooms.Add(new Position(0, 2), new Room("The Treasure Room! It's heavily guarded.", null, new Enemy("Orc Chieftain", 50, 10)));
    }

    public Room? GetRoom(Position pos)
    {
        return _rooms.TryGetValue(pos, out var room) ? room : null;
    }
}