using Abp.AutoMapper;
using BoilerplatePOC.Roles.Dto;
using BoilerplatePOC.Web.Models.Common;

namespace BoilerplatePOC.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
