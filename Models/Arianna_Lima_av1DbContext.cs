using Arianna_Lima_av1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Arianna_Lima_av1.Models
{
    public class Arianna_Lima_av1DbContext : DbContext
    {
        public Arianna_Lima_av1DbContext() : base("Arianna_Lima_av1DbContext")
        {
        }

              

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

    }
}
