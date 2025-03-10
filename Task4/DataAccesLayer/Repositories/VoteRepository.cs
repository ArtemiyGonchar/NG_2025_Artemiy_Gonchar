using DataAccesLayer.DatabaseContext;
using DataAccesLayer.Entities;
using DataAccesLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class VoteRepository : Repository<Vote>, IVoteRepository
    {
        private readonly CrowdfundingDbContext _ctx;

        public VoteRepository(CrowdfundingDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
