using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public record VoteModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;
        public int ProjectId { get; set; }
    }
}
