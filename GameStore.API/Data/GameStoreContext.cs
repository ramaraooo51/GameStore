using System;
using Microsoft.EntityFrameworkCore;
using GameStore.API.Entities;

namespace GameStore.API.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Games> Games => Set<Games>();

    public DbSet<Genre> Genres => Set<Genre>();


}
