namespace StudentList.Models.Domain
{
    public class Student
    {
        //guid is a unique id as oppose to a just id
        public Guid Id { get; set; }

        public string Name { get; set;}
        public string Email { get; set;}

        public DateTime DateofBirth { get; set;}
        public long Tuition { get; set;}
        public string Class { get; set; }
    }
}
