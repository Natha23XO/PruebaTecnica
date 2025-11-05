using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMyper.Models;
using System;

namespace PruebaTecnicaMyper.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Trabajador> Trabajadores { get; set; }

    }
}
