﻿using DataAccesLayer.DatabaseContext;
using DataAccesLayer.Entities;
using DataAccesLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly CrowdfundingDbContext _ctx;

        public CommentRepository(CrowdfundingDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
