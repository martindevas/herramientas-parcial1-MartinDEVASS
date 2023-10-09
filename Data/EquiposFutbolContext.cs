using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using parcial1.Models;

    public class EquiposFutbolContext : DbContext
    {
        public EquiposFutbolContext (DbContextOptions<EquiposFutbolContext> options)
            : base(options)
        {
        }

        public DbSet<parcial1.Models.Equipo> Equipo { get; set; } = default!;

        public DbSet<parcial1.Models.EquipoConsole> EquipoConsole { get; set; } = default!;
    }
