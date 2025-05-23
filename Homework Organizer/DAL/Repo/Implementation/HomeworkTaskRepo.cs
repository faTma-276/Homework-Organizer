using Homework_Organizer.DAL.Entities;
using Homework_Organizer.DAL.Repo.Abstract;

namespace Homework_Organizer.DAL.Repo.Implementation
{
    public class HomeworkTaskRepo : IHomeworkTaskRepo
    {
        private static readonly List<HomeworkTask> tasks = new();
        //private static readonly List<HomeworkTask> tasks = new()
        //{
        //    new HomeworkTask(100, "Math", "Solve equations", DateTime.Now.AddDays(1),true),
        //    new HomeworkTask(101, "Science", "Read chapter 5", DateTime.Now.AddDays(2),false),
        //    new HomeworkTask(102, "History", "Prepare presentation", DateTime.Now.AddDays(3),false)
        //};
        public (bool, string?) Create(int id,string subject, string description, DateTime dueDate)
        {
            try
            {
                if (id <= 0 )
                    return (false, "Id must be greater than 0");
                if (string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(description))
                    return (false, "Subject and description cannot be empty.");
                if (dueDate <= DateTime.Now)
                    return (false, "Due date must be in the future.");
                tasks.Add(new(id,subject,description,dueDate));
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"An error occurred: {ex.Message}");
            }
        }
        public (bool, string?) Complete(int id)
        {
            try
            {
                HomeworkTask task =  tasks.FirstOrDefault(t => t.Id == id);
                if (task is null)
                {
                    return (false, "Task not found");
                }
                if (task.IsCompleted)
                    return (false, "Task is already completed.");
                task.MarkComplete();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, $"An error occurred: {ex.Message}");
            }
        }

        public List<HomeworkTask> GetAll()
        {
            return tasks.ToList();
        }
    }
}
