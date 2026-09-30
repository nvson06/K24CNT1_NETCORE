using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NvsLesson12.Models
{
    [Table("Marks")]
    public class NvsMark
    {
        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public float Score { get; set; }

        // Quan hệ với Subject
        public NvsSubject? Subject { get; set; }

        // Quan hệ với Student
        public NvsStudent? Student { get; set; }
    }
}