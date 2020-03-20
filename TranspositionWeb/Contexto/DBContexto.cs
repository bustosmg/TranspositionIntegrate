using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranspositionWeb.Models;

namespace TranspositionWeb.Contexto
{
    public class DBContexto : DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options)
        {
        }

        public DbSet<NotasModel> notas { set; get; }
        public DbSet<AcordesModel> acordes { set; get; }

    }
}
