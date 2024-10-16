using Microsoft.EntityFrameworkCore;
using PokedecksBackend.Models.Entities;

namespace PokedecksBackend.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Series> Series { get; set; }
    public DbSet<Set> Sets { get; set; }
    public DbSet<Card> Cards { get; set; }
}