namespace DXKuma.Prober.Backend;

public record PlayerInfo
{
    public required int PlayerId
    {
        get;
        init
        {
            if (value is > 99999999 or < 0)
            {
                throw new OverflowException();
            }
            field = value;
        }
    }
    public required Dictionary<int, Dictionary<LevelIndex, Record>> Records { get; init; }
}