using System;

namespace Simulator;

public class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    private bool _nameInitialized = false;
    private bool _levelInitialized = false;

    public string Name
    {
        get => _name;
        set
        {
            if (_nameInitialized) return;
            _nameInitialized = true;

            value = value.Trim();

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            if (value.Length > 25)
                value = value.Substring(0, 25).TrimEnd();

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value.Substring(1);

            _name = value;
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            if (_levelInitialized) return;
            _levelInitialized = true;

            if (value < 1) value = 1;
            if (value > 10) value = 10;

            _level = value;
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public string Info => $"{Name}, Level: {Level}";

    public void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name}, level {Level}.");
    }

    public void Upgrade()
    {
        if (Level < 10)
            Level++;
    }
}

public void Go(Direction direction)
    {
        string directionName = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionName}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        Direction[] parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections);
    }
