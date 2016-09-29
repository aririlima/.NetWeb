using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Arianna_Lima_av1.Models
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            Property(p => p.nome).IsRequired().HasMaxLength(500);
        }
    }
}