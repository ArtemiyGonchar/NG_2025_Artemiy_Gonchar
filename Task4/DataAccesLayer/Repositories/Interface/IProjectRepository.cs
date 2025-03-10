using DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories.Interface
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> CreateProjectAsync(Project project);
        Task<Project> GetByIdWithIncludes(int id);
    }
}
