using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccesLayer.Entities;
using DataAccesLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogicLayer.Services.Classes.CategoryService;

namespace BusinessLogicLayer.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CategoryModel categoryModel)
        {
            var category = _mapper.Map<Category>(categoryModel);
            var categoryCreated = await _categoryRepository.CreateAsync(category);
            return categoryCreated;
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            var categoryModel = _mapper.Map<CategoryModel>(category);
            return categoryModel;
        }
    }
}

