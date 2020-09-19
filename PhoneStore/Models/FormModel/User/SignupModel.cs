using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models.FormModel.User
{
    public class SignupModel
    {
        [Required(ErrorMessage = "Nhập họ tên")]
        public string AccName { get; set; }
        [Required(ErrorMessage = "Nhập số điện thoại")]
        public string AccPhone { get; set; }
        [Required(ErrorMessage = "Nhập Email")]
        public string AccEmail { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu")]
        public string AccPass { get; set; }
        [Required(ErrorMessage = "Nhập lại mật khẩu")]
        public string RePass { get; set; }
        
    }
}
