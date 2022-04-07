using lab_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ViewModels
{
    public class LoginData
    {
        [Required(ErrorMessage = "*")]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password should be between 4 and 20 characters")]
        public string password { get; set; }
    }

    public static class LoginDataEx

    {
        public static LoginData ToViewModel(this User user)
        {
            return new LoginData
            {
                User_Name = user.UserName,
                password = user.Password
            };
        }
    }
}