using System.ComponentModel.DataAnnotations;

namespace NvsLesson08.Models
{
    public class NvsMember
    {
        [Required(ErrorMessage = "Vui lòng nhập mã thành viên.")]
        public string NvsMemberId { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản.")]
        public string NvsUserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string NvsPassword { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        [Display(Name = "Full Name")]
        public string NvsFullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        public string NvsEmail { get; set; } = string.Empty;

    }
}
