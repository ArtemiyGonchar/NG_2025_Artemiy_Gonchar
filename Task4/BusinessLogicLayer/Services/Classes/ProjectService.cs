using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccesLayer.Entities;
using DataAccesLayer.Repositories;
using DataAccesLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Classes
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateProjectAsync(ProjectModel project)
        {
            if (string.IsNullOrWhiteSpace(project.Name))
            {
                throw new ArgumentException("Project name is empty");
            }

            if (project.CreatorId <= 0)
            {
                throw new ArgumentException("Creator Id is incorrect");
            }

            if (string.IsNullOrEmpty(project.Description))
            {
                throw new ArgumentException("Project description is empty");
            }

            if (project.CategoryId <= 0)
            {
                throw new ArgumentException("Category Id must be presented");
            }
            var projectDAL = _mapper.Map<Project>(project);
            var createProject = await _projectRepository.CreateProjectAsync(projectDAL);
            return _mapper.Map<ProjectModel>(createProject).Id;
        }

        public async Task<ProjectModel> GetByIdAsync(int id)
        {
            var project = await _projectRepository.GetByIdWithIncludes(id);
            var projectModel = _mapper.Map<ProjectModel>(project);
            return projectModel;
        }
    }
}
