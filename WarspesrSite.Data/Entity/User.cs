using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarspesrSite.Data.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Hero>? Heroes { get; set; }
    }
}
