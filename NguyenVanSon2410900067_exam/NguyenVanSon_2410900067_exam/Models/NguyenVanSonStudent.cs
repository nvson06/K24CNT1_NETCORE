using System.ComponentModel.DataAnnotations;

namespace NguyenVanSon_2410900067_exam.Models;

public class NguyenVanSonStudent
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Họ và tên")]
    public string NguyenVanSonName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Giới tính")]
    public string NguyenVanSonGender { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Ngày sinh")]
    [DataType(DataType.Date)]
    public DateTime NguyenVanSonBirthday { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string NguyenVanSonEmail { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Số điện thoại")]
    public string NguyenVanSonPhone { get; set; } = string.Empty;

    [Display(Name = "Hoạt động")]
    public bool NguyenVanSonActive { get; set; }
}