using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NvsLesson12.Models
{
    [Table("Banner")]
    public class NvsBanner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên banner không được để trống")]
        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string? Name { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string? Image { get; set; }

        [StringLength(1000)]
        [Column(TypeName = "nvarchar(1000)")]
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public byte Status { get; set; }
    }
}