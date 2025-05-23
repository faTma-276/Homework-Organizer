namespace Homework_Organizer.DAL.Entities
{
    public class HomeworkTask
    {
        public HomeworkTask(int id, string subject, string description, DateTime dueDate)
        {
            Id = id;
            Subject = subject;
            Description = description;
            DueDate = dueDate;
        }
        public HomeworkTask(int id, string subject, string description, DateTime dueDate, bool isCompleted)
        {
            Id = id;
            Subject = subject;
            Description = description;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }

        public int Id { get;private set; }
        public string Subject { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool IsCompleted { get; private set; } = false;
        public void MarkComplete()
        {
            IsCompleted = true;
        }

    }
}
