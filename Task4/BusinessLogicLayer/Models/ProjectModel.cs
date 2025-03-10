using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public record ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int CreatorId { get; set; }
        public UserModel Creator { get; set; } = null!;
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; } = null!;

        public List<CommentModel> Comments { get; set; }
        public List<VoteModel> Votes { get; set; }
    }
}
