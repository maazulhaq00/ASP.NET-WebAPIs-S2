using System.ComponentModel.DataAnnotations;

namespace FrontendASP.Models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }
        public string studentName { get; set; }
        public int studentAge { get; set; }
        public string studentBatchCode { get; set; }
        public string studentPhone { get; set; }
        public string studentGender { get; set; }
    }
}
