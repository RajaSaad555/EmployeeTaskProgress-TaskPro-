using System;
using System.Collections.Generic;
using EmployeeTaskProgress.Models;

namespace EmployeeTaskProgress.ViewModels
{
    public class ReportViewModel
    {
        public List<int> SelectedUserIds { get; set; }
        public List<int> SelectedProjectIds { get; set; }
        public string DateRange { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public List<TaskItem> Results { get; set; }
        public double TotalHours { get; set; }
    }

    public class DashboardViewModel
    {
        public int ClientsCount { get; set; }
        public int ProjectsCount { get; set; }
        public int TasksCount { get; set; }

        public List<Project> RecentProjects { get; set; }
        public List<TaskItem> RecentTasks { get; set; }
    }


}