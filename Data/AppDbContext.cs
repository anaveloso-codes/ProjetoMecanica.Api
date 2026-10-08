
using Microsoft.EntityFrameworkCore;
using ProjetoMecanicaApi.models;
using System.Collections.Generic;


namespace ProjetoMecanicaApi.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Users> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}