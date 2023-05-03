namespace StudentList.Models
{
    public class UpdateStudentViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime DateofBirth { get; set; }
        public long Tuition { get; set; }
        public string Class { get; set; }
    }
}
