
using Homework_Organizer.BLL.Services.Abstract;
using Homework_Organizer.BLL.Services.Implementation;
using Homework_Organizer.DAL.Repo.Abstract;
using Homework_Organizer.DAL.Repo.Implementation;

namespace Homework_Organizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IHomeworkTaskRepo, HomeworkTaskRepo>();
            builder.Services.AddScoped<IHomeworkTaskService, HomeworkTaskService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
