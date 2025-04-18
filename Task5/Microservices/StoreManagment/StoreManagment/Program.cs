using StoreManagmentBL;
using StoreManagmentDAL;
namespace StoreManagment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddStoreManagmentDALLogic(builder.Configuration);
            builder.Services.AddStoreManagmentBusinessLogic();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            // app.UseRouting();

            app.UseAuthorization();
            app.MapControllers();
            /*app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            */
            app.Run();
        }
    }
}
