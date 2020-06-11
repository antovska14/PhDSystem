namespace PhDSystem.Api.Models.Teachers
{
    public class Teacher
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Title { get; set; }
    }
}
