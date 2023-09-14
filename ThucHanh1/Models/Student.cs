namespace ThucHanh1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Branch? Branch { get; set; }// ngành học
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }//Hệ: true-chính qui, false - phi cq
        public string? Address { get; set; }
        public DateTime DateOfBorth { get; set; }
		public IFormFile Img { get; set; }
	}
}
