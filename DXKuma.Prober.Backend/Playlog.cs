using System.Text.Json.Serialization;

namespace DXKuma.Prober.Backend;

public record Playlog
{
    [JsonPropertyName("music_id")]
    public required ChartId ChartId { get; init; }

    [JsonPropertyName("level_index")]
    public required LevelIndex Level { get; init; }

    [JsonPropertyName("play_time")]
    public DateTime? PlayTime { get; init; }

    [JsonPropertyName("play_count")]
    public int? PlayCount { get; init; }

    [JsonPropertyName("achievements")]
    public required int Achievements { get; init; }

    [JsonPropertyName("combo_status")]
    public required ComboStatus ComboStatus { get; init; }

    [JsonPropertyName("sync_status")]
    public required SyncStatus SyncStatus { get; init; }

    [JsonPropertyName("delux_score")]
    public required int DeluxScore { get; init; }
}