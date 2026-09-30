using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NvsLesson12.Models
{
    [Table("Subjects")]
    public class NvsSubject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên môn học không được để trống")]
        [StringLength(100, ErrorMessage = "Tên môn học tối đa 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        public string SubjectName { get; set; }

        // Quan hệ với bảng Marks
        public ICollection<NvsMark>? Marks { get; set; }
    }
}