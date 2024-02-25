using CamposDealerWebProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CamposDealerWebProject.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {        
    }    

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Venda> Vendas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }        
    }
}
