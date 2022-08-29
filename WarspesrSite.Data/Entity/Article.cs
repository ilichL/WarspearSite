using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarspesrSite.Data.Entity
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public Guid SourseId { get; set; }
        public Source Source { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
