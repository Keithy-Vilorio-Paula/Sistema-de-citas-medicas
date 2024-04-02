using Microsoft.EntityFrameworkCore;
using sistema_medico_bd_server.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace sistema_medico_bd_server
{
    public class CitaContext : DbContext
    {
        static string database = "Citasdb.db";

        public DbSet<Citas> Citas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Filename=" + database,
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(

                        Assembly.GetExecutingAssembly().FullName

                        );
                });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>().ToTable("Citas");
            modelBuilder.Entity<Citas>(entity => {

                entity.HasKey(a => a.id);

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}