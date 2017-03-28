using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MODEL
{
    public class T_UserConfig
    {
        [Key]
        public int ConfigId { get; set; }

        [Required(ErrorMessage ="必填")]
        [DisplayName("启用注册")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 用户名之间用“|”隔开
        /// </summary>
        [DisplayName("禁止使用的用户名")]
        public string ProhibitUserName { get; set; }

        [Required(ErrorMessage ="必填")]
        [DisplayName("启用管理员验证")]
        public bool EnabledAdminVerify { get; set; }

        [Required(ErrorMessage ="必填")]
        [DisplayName("启用邮件验证")]
        public bool EnableEmailVerify { get; set; }

        [Required(ErrorMessage ="必填")]
        [DisplayName("默认用户组Id")]
        public int DefaultGroupId { get; set; }
    }
}
