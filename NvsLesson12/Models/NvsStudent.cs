using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NvsLesson12.Models
{
    [Table("Student")]
    [Index(nameof(StudentEmail), IsUnique = true)]
    [Index(nameof(StudentPhone), IsUnique = true)]
    public class NvsStudent
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sinh viên không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string StudentName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string StudentEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string StudentPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string StudentAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ảnh sinh viên không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string StudentAvatar { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [Column(TypeName = "date")]
        public DateTime StudentBirthday { get; set; }

        // Khóa ngoại tới StdClass
        [Required]
        public int ClassId { get; set; }

        // Quan hệ với StdClass
        [ForeignKey(nameof(ClassId))]
        public NvsStdClass? StdClass { get; set; }

        // Quan hệ 1 - nhiều với Mark
        public ICollection<NvsMark> Marks { get; set; }
            = new List<NvsMark>();
    }
}