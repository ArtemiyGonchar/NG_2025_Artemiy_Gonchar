using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentModel> GetByIdAsync(int id);
        Task<int> CreateAsync(CommentModel commentModel);
    }
}
