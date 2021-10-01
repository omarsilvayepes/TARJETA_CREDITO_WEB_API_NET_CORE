using BackendTarjeta.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTarjeta
{
    public class AplicationDBContext:DbContext
    {
        // mapear modelo con la tabla en la BD
        public DbSet<TarjetaCredito> tarjetaCredito { get; set; }
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        {

        }
    }
}
