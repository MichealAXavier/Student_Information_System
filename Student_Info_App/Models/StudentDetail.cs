using System.ComponentModel.DataAnnotations;

namespace Student_Info_App.Models
{
    public class StudentDetail : Student
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public new string Name { get; set; }

        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
        public new int Age { get; set; }

        [StringLength(10, ErrorMessage = "Gender cannot exceed 10 characters.")]
        public new string Gender { get; set; }

        [StringLength(100, ErrorMessage = "Course cannot exceed 100 characters.")]
        public new string Course { get; set; }
    }
}
