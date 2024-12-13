using System.Collections.Generic;

namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string input)
    {
        List<Direction> directions = new();

        foreach (char c in input.ToUpper()) // Zamiana na wielkie litery
        {
            switch (c)
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;
            }
        }

        return directions.ToArray(); // Zamiana na tablicę
    }
}
