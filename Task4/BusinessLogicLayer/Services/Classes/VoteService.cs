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
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IMapper _mapper;

        public VoteService(IVoteRepository voteRepository, IMapper mapper)
        {
            _voteRepository = voteRepository;
            _mapper = mapper;
        }
        public async Task<VoteModel> GetByIdAsync(int id)
        {
            var vote = await _voteRepository.GetAsync(id);
            return _mapper.Map<VoteModel>(vote);
        }

        public async Task<int> CreateAsync(VoteModel voteModel)
        {
            var vote = _mapper.Map<Vote>(voteModel);
            var voteCreated = await _voteRepository.CreateAsync(vote);
            return voteCreated;
        }
    }
}
