using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VideoGame.Api.Entities;

namespace VideoGame.Api.Data;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
    {
    }

    //define entities
    public DbSet<Game> Games => Set<Game>(); //{ get; set; }

    //override from base context
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //provide the current executing assembly
        //base.OnModelCreating(modelBuilder);
    }
}
