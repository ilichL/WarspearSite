using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarspesrSite.Data.Entity
{
    public class Hero : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
