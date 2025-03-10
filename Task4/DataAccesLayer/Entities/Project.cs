using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int CreatorId { get; set; }
        public User Creator { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public virtual List<Comment> Comments { get; set; }
        public virtual List<Vote> Votes { get; set; }
    }
}
