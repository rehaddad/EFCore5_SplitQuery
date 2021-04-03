using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore5_SplitQuery
{
    public class BancoContexto : DbContext
    {
        public BancoContexto() { }

        public DbSet<Etapa> Etapas { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }


protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    //optionsBuilder.UseSqlServer(@"Data Source=EARTH;Initial Catalog=EFCoreSplitQuery;Integrated Security=True");

    // SplitQuery para todas as consultas
    optionsBuilder.UseSqlServer(@"Data Source=EARTH;Initial Catalog=EFCoreSplitQuery;Integrated Security=True",
        o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

    // LOGS
    optionsBuilder.EnableSensitiveDataLogging();
    optionsBuilder
    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etapa>().HasData(
            new Etapa { EtapaId = 1, Cidade = "Moto GP Qatar" },
            new Etapa { EtapaId = 2, Cidade = "Moto GP Italia Mugello" }
            );

            modelBuilder.Entity<Piloto>().HasData(
            new Piloto { PilotoId = 1, Nome = "Marque Marques", Pais="Espanha", EtapaId = 1 },
            new Piloto { PilotoId = 2, Nome = "Valentino Rossi", Pais="Italia", EtapaId = 1 },
            new Piloto { PilotoId = 3, Nome = "Franco Morbidelli", Pais="Italia", EtapaId = 1 },
            new Piloto { PilotoId = 4, Nome = "Miguel Oliveira", Pais="Portugal", EtapaId = 1 },
            new Piloto { PilotoId = 5, Nome = "Danilo Petrucci", Pais = "Espanha", EtapaId = 2 },
            new Piloto { PilotoId = 6, Nome = "Takkaki Nakagami", Pais = "Japao", EtapaId = 2 },
            new Piloto { PilotoId = 7, Nome = "Luca Marini", Pais = "Italia", EtapaId = 2 },
            new Piloto { PilotoId = 8, Nome = "Iker Lecuona", Pais = "Espanha", EtapaId = 2 },
            new Piloto { PilotoId = 9, Nome = "Lorenzo Salvadori", Pais = "Italia", EtapaId = 2 }
            );
        }
    }
}