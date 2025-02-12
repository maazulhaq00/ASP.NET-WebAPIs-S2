using System.ComponentModel.DataAnnotations;

namespace StudentCRUDAPIs.Models
{
    public class Student
    {
        [Key]
        public int? StudentId { get; set; }
        [Required]
        public String? StudentName { get; set; }
        [Required]
        public int? StudentAge { get; set; }
        [Required]
        public String? StudentBatchCode { get; set; }
        [Required]
        public String? StudentPhone { get; set; }
        [Required]
        public String? StudentGender { get; set; }

    }
}
