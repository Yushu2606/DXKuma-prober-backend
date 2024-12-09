namespace DXKuma.Prober.Backend;

public record Record
{
    public DateTime? PlayTime { get; init; }

    public required DateTime UploadTime
    {
        get;
        init
        {
            if (PlayTime > value)
            {
                throw new InvalidDataException();
            }

            field = value;
        }
    }

    public int? PlayCount
    {
        get;
        init
        {
            if (value < 0)
            {
                throw new OverflowException();
            }

            field = value;
        }
    }

    public required int Achievements
    {
        get;
        init
        {
            if (value is > 0xF6950 or < 0)
            {
                throw new OverflowException();
            }

            field = value;
        }
    }

    public required ComboStatus ComboStatus { get; init; }
    public required SyncStatus SyncStatus { get; init; }

    public required int DeluxScore
    {
        get;
        init
        {
            if (value < 0)
            {
                throw new OverflowException();
            }

            field = value;
        }
    }
}