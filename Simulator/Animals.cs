namespace Simulator;

public class Animals
{
    private string _description = "Unknown"; // Domyślna wartość, aby uniknąć ostrzeżeń

    public required string Description
    {
        get => _description;
        init
        {
            // Usunięcie spacji na początku i końcu
            value = value.Trim();

            // Co najmniej 3 znaki
            if (value.Length < 3)
                value = value.PadRight(3, '#');

            // Maksymalnie 15 znaków, usuń spacje na końcu, zapewnij co najmniej 3 znaki
            if (value.Length > 15)
                value = value.Substring(0, 15).TrimEnd();

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            // Pierwsza litera na wielką
            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value.Substring(1);

            _description = value;
        }
    }

    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
