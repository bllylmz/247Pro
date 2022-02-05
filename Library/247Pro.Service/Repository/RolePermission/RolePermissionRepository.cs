using _247Pro.Model.Context;
using _247Pro.Service.Repository.Base;
using EF = _247Pro.Model.Entities;

namespace _247Pro.Service.Repository.RolePermission
{
    public class RolePermissionRepository : Repository<EF.RolePermission>, IRolePermissionRepository
    {
        private readonly DataContext _context;
        public RolePermissionRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
