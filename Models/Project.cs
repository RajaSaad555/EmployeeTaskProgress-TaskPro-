namespace EmployeeTaskProgress.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }

        // Foreign Key
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        // Navigation property
        public virtual ICollection<TaskItem> Tasks { get; set; }
    }

}
