using static System.Console;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCore5_SplitQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Split Query no EF Core 5!");

            using (var ctx = new BancoContexto())
            {
                WriteLine("Listar as etapas:");
                foreach (var etapa in ctx.Etapas)
                {
                    WriteLine($" - {etapa.Cidade}");
                }

                WriteLine("Listar os Pilotos:");
                foreach (var p in ctx.Pilotos)
                {
                    WriteLine($"{p.PilotoId} - {p.Nome} - {p.Pais} - etapa: {p.Etapa.Cidade}");
                }

                // usando Include
                var etapasInclude = ctx.Etapas
                                        .Include(p => p.Pilotos)
                                        .ToList();

                WriteLine("Listar as etapas e pilotos:");
                foreach (var etapa in etapasInclude)
                {
                    WriteLine($" - {etapa.Cidade}");
                    foreach (var p in etapa.Pilotos)
                    {
                        WriteLine($"{p.PilotoId} - {p.Nome} - {p.Pais}");
                    }
                }

                var etapasassplitquery = ctx.Etapas
                    .Include(p => p.Pilotos)
                    .AsSplitQuery()
                    .ToList();

                WriteLine("listar as etapas e pilotos com assplitquery():");
                foreach (var etapa in etapasassplitquery)
                {
                    WriteLine($" - {etapa.Cidade}");
                    foreach (var p in etapa.Pilotos)
                    {
                        WriteLine($"{p.PilotoId} - {p.Nome} - {p.Pais}");
                    }
                }

                // mesmo no OnConfiguring do Contexto se estiver setada para Split,
                // é possível definir para executar como única consulta
                var etapasAsSingleQuery = ctx.Etapas
                    .Include(p => p.Pilotos)
                    .AsSingleQuery()
                    .ToList();

                WriteLine("Listar as etapas e pilotos com AsSplitQuery():");
                foreach (var etapa in etapasAsSingleQuery)
                {
                    WriteLine($" - {etapa.Cidade}");
                    foreach (var p in etapa.Pilotos)
                    {
                        WriteLine($"{p.PilotoId} - {p.Nome} - {p.Pais}");
                    }
                }
                ReadLine();
            }
        }
    }
}
