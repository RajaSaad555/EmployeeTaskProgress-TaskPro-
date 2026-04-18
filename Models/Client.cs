namespace EmployeeTaskProgress.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }

        // Navigation property
        public virtual ICollection<Project> Projects { get; set; }
    }

}
