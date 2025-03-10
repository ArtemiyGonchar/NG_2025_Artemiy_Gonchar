using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services.Interfaces;
using DataAccesLayer.Entities;
using DataAccesLayer.Repositories;
using DataAccesLayer.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Classes
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<CommentModel> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetAsync(id);
            return _mapper.Map<CommentModel>(comment);
        }

        public async Task<int> CreateAsync(CommentModel commentModel)
        {
            var comment = _mapper.Map<Comment>(commentModel);
            var commentCreated = await _commentRepository.CreateAsync(comment);
            return commentCreated;
        }
    }
}
