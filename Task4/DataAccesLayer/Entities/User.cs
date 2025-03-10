using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual List<Project> Projects { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Vote> Votes { get; set; }
    }
}
