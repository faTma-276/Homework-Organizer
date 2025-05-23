using Homework_Organizer.DAL.Entities;

namespace Homework_Organizer.DAL.Repo.Abstract
{
    public interface IHomeworkTaskRepo
    {
        (bool, string?) Create(int id, string subject, string description, DateTime dueDate);
        (bool, string?) Complete(int id);
        List<HomeworkTask> GetAll();
    }
}
