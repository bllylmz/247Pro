using _247Pro.Model.Context;
using _247Pro.Service.Repository.Base;
using EF = _247Pro.Model.Entities;

namespace _247Pro.Service.Repository.RoleGroupPermissionDetail
{
    public class RoleGroupPermissionDetailRepository : Repository<EF.RoleGroupPermissionDetail>, IRoleGroupPermissionDetailRepository
    {
        private readonly DataContext _context;
        public RoleGroupPermissionDetailRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
