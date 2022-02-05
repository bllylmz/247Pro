using _247Pro.Model.Context;
using _247Pro.Service.Repository.Base;
using EF = _247Pro.Model.Entities;

namespace _247Pro.Service.Repository.RoleGroup
{
    public class RoleGroupRepository : Repository<EF.RoleGroup>, IRoleGroupRepository
    {
        private readonly DataContext _context;
        public RoleGroupRepository(DataContext context) 
            : base(context)
        {
            _context = context;
        }
    }
}
