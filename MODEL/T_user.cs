using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MODEL
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class T_User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{1}到{0}个字符")]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "用户组ID")]
        public int GroupID { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "显示名")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "必填")]
        [DisplayName("邮箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 用户状态
        /// 0正常，1锁定，2未通过邮件验证，3未通过管理员，4删除
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistrationTime { get; set; }

        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 上次登陆IP
        /// </summary>
        public string LastLoginIP { get; set; }

        /// <summary>
        /// 用户组类
        /// </summary>
        public virtual T_UserGroup UserGroup { get; set; }
    }
}
