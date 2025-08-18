using Microsoft.EntityFrameworkCore;

namespace NovoMobile.Api.Data
{
    // Herança de DbContext
    public class AppDbContext : DbContext 
    {
        // Construtor que recebe as opções de configuração do DbContext como: Nome do banco, string de conexão, servidor, etc.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {           
        }

        // Propriedade que referencia a tabela de veículos a partir do Models Estacionamento
        public DbSet<Models.Estacionamento> VeiculosEstacionados { get; set; }
    }
}
