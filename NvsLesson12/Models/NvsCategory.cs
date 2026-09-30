using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NvsLesson12.Models
{
    [Table("Category")]
    public class NvsCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "tinyint")]
        public byte Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<NvsProduct>? Products { get; set; }
    }
}