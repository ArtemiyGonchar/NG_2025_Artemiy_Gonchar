using DataAccesLayer.DatabaseContext;
using DataAccesLayer.Repositories;
using DataAccesLayer.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccesLayer
{
    public static class DataAccesLayerInjection
    {
        public static void AddDataAccesLayer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CrowdfundingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"),
                    builder => builder.MigrationsAssembly(typeof(CrowdfundingDbContext).Assembly.FullName));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();
        }
    }
}
