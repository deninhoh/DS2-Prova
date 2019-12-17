using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaYagoDS2.Models;

namespace ProvaYagoDS2.Data
{
    public class ProvaYagoDS2Context : DbContext
    {
        public ProvaYagoDS2Context (DbContextOptions<ProvaYagoDS2Context> options)
            : base(options)
        {
        }

        public DbSet<ProvaYagoDS2.Models.Pessoa> Pessoa { get; set; }

        public DbSet<ProvaYagoDS2.Models.Alimento> Alimento { get; set; }
    }
}
