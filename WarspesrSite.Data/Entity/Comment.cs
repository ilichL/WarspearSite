using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarspesrSite.Data.Entity
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public int Rate { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
