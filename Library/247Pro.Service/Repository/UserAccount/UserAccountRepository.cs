using _247Pro.Model.Context;
using _247Pro.Service.Repository.Base;
using EF = _247Pro.Model.Entities;

namespace _247Pro.Service.Repository.UserAccount
{
    public class UserAccountRepository : Repository<EF.UserAccount>, IUserAccountRepository
    {
        private readonly DataContext _context;
        public UserAccountRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
