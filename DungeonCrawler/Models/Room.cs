using System.Collections.Generic;

namespace DungeonCrawler.Models;

public class Room
{
    public string Description { get; set; }
    public string? Item { get; set; }
    public Enemy? RoomEnemy { get; set; }

    public Room(string description, string? item = null, Enemy? enemy = null)
    {
        Description = description;
        Item = item;
        RoomEnemy = enemy;
    }
}