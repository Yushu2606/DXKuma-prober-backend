namespace DXKuma.Prober.Backend;

/// <summary>
///     谱面ID对象。
/// </summary>
public record ChartId
{
    /// <summary>
    ///     通过谱面ID生成谱面ID对象。
    /// </summary>
    /// <param name="fullId">谱面ID（0-999999）。</param>
    /// <exception cref="OverflowException">输入不在正确的范围内。</exception>
    public ChartId(int fullId)
    {
        MusicId = fullId % 0x2710;
        DeluxId = fullId / 0x2710 % 0xA;
        UtageId = fullId / 0x186A0;
    }

    /// <summary>
    ///     通过乐曲ID及谱面类型生成谱面ID对象。
    /// </summary>
    /// <param name="musicId">乐曲ID（0-9999）。</param>
    /// <param name="chartType">谱面类型。</param>
    /// <exception cref="OverflowException">输入不在正确的范围内。</exception>
    [Obsolete("请使用`ChartId(fullId)`。")]
    public ChartId(int musicId, ChartType chartType)
    {
        MusicId = musicId;
        if (chartType.HasFlag(ChartType.Utage))
        {
            UtageId = 1;
        }

        if (chartType.HasFlag(ChartType.Delux))
        {
            DeluxId = 1;
        }
    }

    /// <summary>
    ///     乐曲ID（0-9999）。
    /// </summary>
    /// <exception cref="OverflowException">输入不在正确的范围内。</exception>
    public int MusicId
    {
        get;
        init
        {
            if (value is > 0x270F or < 0)
            {
                throw new OverflowException();
            }

            field = value;
        }
    }

    /// <summary>
    ///     DXID（0-9）。
    /// </summary>
    /// <exception cref="OverflowException">输入不在正确的范围内。</exception>
    public int DeluxId
    {
        get;
        init
        {
            if (value is > 9 or < 0)
            {
                throw new OverflowException();
            }

            field = value;
        }
    }

    /// <summary>
    ///     宴会场ID（0-9）。
    /// </summary>
    /// <exception cref="OverflowException">输入不在正确的范围内。</exception>
    public int UtageId
    {
        get;
        init
        {
            if (value is > 9 or < 0)
            {
                throw new OverflowException();
            }

            field = value;
        }
    }

    /// <summary>
    ///     谱面类型
    /// </summary>
    public ChartType Type
    {
        get
        {
            if (UtageId > 0)
            {
                return ChartType.Utage;
            }

            if (DeluxId > 0)
            {
                return ChartType.Delux;
            }

            return ChartType.Standard;
        }
    }

    /// <summary>
    ///     转换为谱面ID。
    /// </summary>
    /// <returns>谱面ID。</returns>
    public int ToFullId()
    {
        return UtageId * 0x186A0 + DeluxId * 0x2710 + MusicId;
    }

    public override string ToString()
    {
        return ToFullId().ToString();
    }
}