using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NvsLesson12.Models
{
    [Table("StdClass")]
    public class NvsStdClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên lớp không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string ClassName { get; set; } = string.Empty;

        // Quan hệ 1 - nhiều với Student
        public ICollection<NvsStudent> Students { get; set; }
            = new List<NvsStudent>();
    }
}