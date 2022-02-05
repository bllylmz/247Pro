using _247Pro.Common.DTOs.UserAccount;

namespace _247Pro.Common.WorkContext
{
    public interface IWorkContext
    {
        UserAccountResponse CurrentUser { get; set; }
    }
}
