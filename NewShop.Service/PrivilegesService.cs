using NewShop.Entity;
using NewShop.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShop.Service
{
    public class PrivilegesService : RepositoryBase<RoleInfo>, IPrivilegesService
    {

        public IQueryable<RoleInfo> GetRoles()
        {
            return this.LoadAll(r=>r.DeleteMark==false);
        }
    }
}
