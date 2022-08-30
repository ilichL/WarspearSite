using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarspearSite.Core.Interfaces.Data;
using WarspesrSite.Data;
using WarspesrSite.Data.Entity;

namespace WarspearSite.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Article> articleRepository;
        private readonly IRepository<Comment> commentRepository;
        private readonly IRepository<Hero> heroRepository;
        private readonly IRepository<Role> roleRepository;
        private readonly IRepository<Skill> skillRepository;
        private readonly IRepository<Source> sourceRepository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<UserRole> userRoleRepository;

        public UnitOfWork(IRepository<Article> articleRepository,
            IRepository<Comment> commentRepository,
            IRepository<Hero> heroRepository,
            IRepository<Role> roleRepository,
            IRepository<Skill> skillRepository,
            IRepository<Source> sourceRepository,
            IRepository<User> userRepository,
            IRepository<UserRole> userRoleRepository,
            Context context)
        {
            this.articleRepository = articleRepository;
            this.commentRepository = commentRepository;
            this.heroRepository = heroRepository;
            this.roleRepository = roleRepository;
            this.skillRepository = skillRepository;
            this.sourceRepository = sourceRepository;
            this.userRepository = userRepository;
            this.userRoleRepository = userRoleRepository;
            this.context = context;
        }

        public IRepository<Article> Articles => articleRepository;
        public IRepository<Comment> Comments => commentRepository;
        public IRepository<Hero> Heroes => heroRepository;
        public IRepository<Role> Roles => roleRepository;
        public IRepository<Skill> Skills => skillRepository;
        public IRepository<Source> Sources => sourceRepository;
        public IRepository<User> Users => userRepository;
        public IRepository<UserRole> UserRoles => userRoleRepository;

        public async Task<int> CommitChanges()
        {
            return await context.SaveChangesAsync();
        }

        private readonly Context context;
    }
}
