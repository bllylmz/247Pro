using _247Pro.Common.WorkContext;
using _247Pro.Service.Repository.RoleGroupPermissionDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace _247Pro.API
{
    public class PermissionAttribute : ActionFilterAttribute
    {
        private readonly string _permission;

        public PermissionAttribute(string permission)
        {
            _permission = permission;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new ContentResult() { StatusCode = 401, Content = "You_Are_Not_Authorized_For_This_Transaction" };
            }

            var _workContext = context.HttpContext.RequestServices.GetService<IWorkContext>();

            var _roleGroupPermissionDetailRepository = context.HttpContext.RequestServices.GetService<IRoleGroupPermissionDetailRepository>();

            var userPermissionClaimSet = _roleGroupPermissionDetailRepository.GetByParam(x => x.RoleGroupId == _workContext.CurrentUser.RoleGroupId && x.RolePermission.Code == _permission).Result;
            if (userPermissionClaimSet == null || userPermissionClaimSet.Value == false)
                context.Result = new ContentResult() { StatusCode = 401, Content = "You_Are_Not_Authorized_For_This_Transaction" };
        }

    }
}
