using Abp.Authorization;
using BoilerplatePOC.Authorization.Roles;
using BoilerplatePOC.Authorization.Users;

namespace BoilerplatePOC.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
