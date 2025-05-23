using Homework_Organizer.BLL.DTO;
using Homework_Organizer.DAL.Entities;

namespace Homework_Organizer.BLL.Services.Abstract
{
    public interface IHomeworkTaskService
    {
        Task<(bool, string?)> Create(HomeworkDto task);
        Task<(bool Success, string? ErrorMessage)> Complete(int id);
        List<HomeworkTask> GetAll();
    }
}
