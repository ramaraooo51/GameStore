using Microsoft.EntityFrameworkCore;
using GameStore.API.Entities;

namespace GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Games> Game => Set<Games>();

    public DbSet<Genre> Genre => Set<Genre>();


}
