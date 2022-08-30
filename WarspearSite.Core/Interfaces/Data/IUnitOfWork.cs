using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspesrSite.Data.Entity;

namespace WarspearSite.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
        IRepository<Article> Articles { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Hero> Heroes { get; }
        IRepository<Role> Roles { get; }
        IRepository<Skill> Skills { get; }
        IRepository<Source> Sources { get; }
        IRepository<User> Users { get; }
        IRepository<UserRole> UserRoles { get; }
        Task<int> CommitChanges();
    }
}
