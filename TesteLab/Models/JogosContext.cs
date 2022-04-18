using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TesteLab.Models
{
    public class JogosContext : DbContext
    {
        public DbSet<Jogos> Jogos { get; set; }
    }
}