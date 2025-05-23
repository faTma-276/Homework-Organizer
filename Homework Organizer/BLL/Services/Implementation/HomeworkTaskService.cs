using System.Threading.Tasks;
using Homework_Organizer.BLL.DTO;
using Homework_Organizer.BLL.Services.Abstract;
using Homework_Organizer.DAL.Entities;
using Homework_Organizer.DAL.Repo.Abstract;

namespace Homework_Organizer.BLL.Services.Implementation
{
    public class HomeworkTaskService : IHomeworkTaskService
    {
        private readonly IHomeworkTaskRepo homeworkTaskRepo;

        public HomeworkTaskService(IHomeworkTaskRepo homeworkTaskRepo)
        {
            this.homeworkTaskRepo = homeworkTaskRepo;
        }
        public async Task<(bool Success, string? ErrorMessage)> Complete(int id)
        {
            try
            {
                var result = homeworkTaskRepo.Complete(id);
                if (result.Item1)
                    return (true, null);
                return (false, result.Item2);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> Create(HomeworkDto task)
        {
            try
            {
                if (task is null)
                    return (false, "please insert task fileds");
                var result = homeworkTaskRepo.Create(task.Id, task.Subject, task.Description, task.DueDate);
                if (result.Item1)
                    return (true, null);
                return (false, result.Item2);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public List<HomeworkTask> GetAll()
        {
            try
            {
                var tasks =  homeworkTaskRepo.GetAll();
                //var result = mapper.Map<List<HomeworkDto>>(tasks);
                return tasks;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while getting all tasks", ex);
            }
        }
    }
}
