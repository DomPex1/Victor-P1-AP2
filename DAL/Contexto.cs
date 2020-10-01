using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Victor_P1_AP2.Models;

namespace Victor_P1_AP2.DAL{

    public class Contexto : DbContext{
        public DbSet<Categorias> Categorias {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Categoria.db");
        }
    }

}