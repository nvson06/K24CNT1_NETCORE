using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NvsLesson09.Models.DataModels
{
    // Data Annotation - Validation
    public class NvsMember
    {
        public int NvsMemberId { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không để trống")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Tên đăng nhập có độ dài từ 3 - 20 ký tự")]
        public string NvsUserName { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không để trống")]
        [DataType(DataType.Password)]
        public string NvsPassword { get; set; }

        [DisplayName("Email")]
        public string NvsEmail { get; set; }

        [DisplayName("Số điện thoại")]
        public string NvsPhoneNumber { get; set; }

        [DisplayName("Họ và tên")]
        public string NvsFullname { get; set; }

        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NvsBirthday { get; set; }
    }
}