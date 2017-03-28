using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MODEL
{
    public class T_UserGroup
    {
        [Key]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{1}到{0}个字")]
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 用户组类型
        /// 0普通类型（普通注册用户），1特权类型（vip类型），3管理类型（管理权限类型）
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "用户组类型")]
        public int GroupType { get; set; }

        [Required(ErrorMessage = "必填")]
        [StringLength(50, ErrorMessage = "少于{0}个字")]
        [DisplayName("说明")]
        public string Description { get; set; }
    }
}
