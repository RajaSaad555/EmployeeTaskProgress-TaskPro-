using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTaskProgress.Models
{
    [Table("tasks")] // ⚠️ database table ka naam explicitly specify

    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime TaskDateTime { get; set; }

        // Check karein ke yeh line maujood hai
        public DateTime EndDateTime { get; set; }
        public int? UserId { get; set; } // 'int?' ka matlab hai ke ye khali ho sakta hai

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }

}
