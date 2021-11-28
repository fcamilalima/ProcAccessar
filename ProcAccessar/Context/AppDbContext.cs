using Microsoft.EntityFrameworkCore;
using ProcAccessar.Models;
using ProcAccessar.ViewModels;

namespace ProcAccessar.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Processo> Processos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<ProcessoPesquisaViewModel> ProcessoPesquisas{ get; set; }

}



