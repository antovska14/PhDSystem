namespace PhDSystem.Data.Models
{
    public class TeacherDetails
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Degree { get; set; }

        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public string Email { get; set; }
    }
}
