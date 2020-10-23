using CrudUsuarios.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudUsuarios.Context
{
    public class CrudUserContext : DbContext
    {
        public CrudUserContext(DbContextOptions<CrudUserContext> options) : base(options)
        {   

        }

        public DbSet<User> User { get; set; }   
    }
}
