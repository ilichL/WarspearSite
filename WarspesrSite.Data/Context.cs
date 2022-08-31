using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspesrSite.Data.Entity;

namespace WarspesrSite.Data
{
    public class Context : DbContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Hero> Heroes { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Skill> skills { get; set; }
        DbSet<Source> sources { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<State> States { get; set; }


        public Context (DbContextOptions<Context> options)
            : base (options)
        {}
    }
}
