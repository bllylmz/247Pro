using _247Pro.Model.Context;
using _247Pro.Service.Repository.Base;
using EF = _247Pro.Model.Entities;

namespace _247Pro.Service.Repository.AccountRolePermission
{
    public class AccountRolePermissionRepository : Repository<EF.AccountRolePermission>, IAccountRolePermissionRepository
    {
        private readonly DataContext _context;
        public AccountRolePermissionRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
