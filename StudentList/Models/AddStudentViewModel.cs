namespace StudentList.Models
{
    public class AddStudentViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime DateofBirth { get; set; }
        public long Tuition { get; set; }
        public string Class { get; set; }
    }
}
