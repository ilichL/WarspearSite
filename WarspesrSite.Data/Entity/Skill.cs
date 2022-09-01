using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarspesrSite.Data.Entity
{
    public class Skill : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SkillPoint { get; set; }
        public Guid HeroId { get; set; }
        public virtual Hero Hero { get; set; }
    }
}
