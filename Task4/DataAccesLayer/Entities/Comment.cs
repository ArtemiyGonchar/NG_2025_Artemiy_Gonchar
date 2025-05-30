﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; } = null!;
        public DateTime Date { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

    }
}
