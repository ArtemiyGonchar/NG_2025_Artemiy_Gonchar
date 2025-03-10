using DataAccesLayer.DatabaseContext;
using DataAccesLayer.Entities;
using DataAccesLayer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly CrowdfundingDbContext _ctx;

        public ProjectRepository(CrowdfundingDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            _ctx.Projects.Add(project);
            await _ctx.SaveChangesAsync();
            return project;
        }

        public async Task<Project> GetByIdWithIncludes(int id)
        {
            return await _ctx.Set<Project>().Include(x => x.Category).Include(x => x.Votes).Include(x => x.Comments).ThenInclude(x => x.User).FirstAsync(x => x.Id.Equals(id));
        }
    }
}
