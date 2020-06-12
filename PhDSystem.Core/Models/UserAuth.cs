namespace PhDSystem.Core.Models
{
    public class UserAuth
    {
        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool CanAccessStudents { get; set; }
        public bool CanAccessSupervisors { get; set; }
        public bool CanAddStudents { get; set; }
        public bool CanAddSupervisors { get; set; }
        public bool CanDeleteStudents { get; set; }
        public bool CanDeleteSupervisors { get; set; }

        public UserAuth() : base()
        {
            UserName = "Not authorized";
            BearerToken = string.Empty;
        }
    }
}
