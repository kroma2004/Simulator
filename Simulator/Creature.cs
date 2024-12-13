using System;

namespace Simulator;

public class Creature
{
    private string _name = "Unknown"; // Domyślna wartość dla Name
    private int _level = 1; // Domyślna wartość dla Level
    private bool _nameInitialized = false;
    private bool _levelInitialized = false;

    public string Name
    {
        get => _name;
        set
        {
            if (_nameInitialized) return; // Można nadać tylko raz
            _nameInitialized = true;

            // Usunięcie spacji na początku i końcu
            value = value.Trim();

            // Co najmniej 3 znaki
            if (value.Length < 3)
                value = value.PadRight(3, '#');

            // Maksymalnie 25 znaków, usuń spacje na końcu, zapewnij co najmniej 3 znaki
            if (value.Length > 25)
                value = value.Substring(0, 25).TrimEnd();

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            // Pierwsza litera na wielką
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
            if (_levelInitialized) return; // Można nadać tylko raz
            _levelInitialized = true;

            // Zakres 1-10
            if (value < 1) value = 1;
            if (value > 10) value = 10;

            _level = value;
        }
    }

    // Konstruktor z parametrami
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    // Konstruktor bezparametrowy
    public Creature() { }

    // Właściwość Info
    public string Info => $"{Name}, Level: {Level}";

    // Metoda SayHi
    public void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name}, level {Level}.");
    }

    // Metoda Upgrade
    public void Upgrade()
    {
        if (Level < 10)
            Level++;
    }
}

public void Go(Direction direction)
    {
        string directionName = direction.ToString().ToLower(); // Nazwa kierunku ma być z małej litery
        Console.WriteLine($"{Name} goes {directionName}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction); // Wywołanie pierwszej metody Go
        }
    }

    public void Go(string directions)
    {
        Direction[] parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections); // Wywołanie metody Go z tablicą kierunków
    }
