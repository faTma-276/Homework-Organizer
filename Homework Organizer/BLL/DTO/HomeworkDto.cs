using System.ComponentModel.DataAnnotations;

namespace Homework_Organizer.BLL.DTO
{
    public class HomeworkDto
    {
        public int Id { get;  set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "DueDate must be in the format yyyy-MM-dd ")]
        public DateTime DueDate { get; set; }
    }
}
