using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain;

public class ApplicationDbContext : DbContext
{
    public DbSet<Lancamento> Lancamentos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lancamento>().HasKey(l => l.Id);
        modelBuilder.Entity<ConsolidadoDiario>().HasNoKey(); // Projeção apenas para leitura
    }
}
