using Microsoft.EntityFrameworkCore;

namespace DXKuma.Prober.Backend;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public required DbSet<PlayerInfo> PlayerInfos { get; init; }
}