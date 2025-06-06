﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public record CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;
        public int ProjectId { get; set; }
    }
}
