using System;
using System.ComponentModel.DataAnnotations;

namespace NvsLesson09.Models.DataModels.DataViewModels
{
    public class NvsMemberRegister
    {
        [Required(ErrorMessage = "Tên đăng nhập không để trống")]
        public string NvsUserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không để trống")]
        [DataType(DataType.Password)]
        public string NvsPassword { get; set; }

        [Required(ErrorMessage = "Email không để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string NvsEmail { get; set; }

        public string NvsPhoneNumber { get; set; }

        public string NvsFullname { get; set; }

        [DataType(DataType.Date)]
        public DateTime NvsBirthday { get; set; }
    }
}