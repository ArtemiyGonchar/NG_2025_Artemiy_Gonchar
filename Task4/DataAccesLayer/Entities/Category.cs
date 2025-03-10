using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public class Category : BaseEntity
    {
        public string Description { get; set; } = null!;

        public virtual List<Project> Projects { get; set; }
    }
}
