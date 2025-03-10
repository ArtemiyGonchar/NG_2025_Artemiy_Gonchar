using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IProjectService
    {
        Task<int> CreateProjectAsync(ProjectModel project);
        Task<ProjectModel> GetByIdAsync(int id);
    }
}
