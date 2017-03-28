using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{
    public class MVCDb : DbContext
    {
        public MVCDb() : base("MVCDb")
        {
        }

        public DbSet<DALUser> T_User { get; set; }
        public DbSet<T_UserGroup> T_UserGroup { get; set; }
        public DbSet<T_UserConfig> T_UserConfig { get; set; }
    }
}
