using System.Collections.Generic;
using BoilerplatePOC.Roles.Dto;

namespace BoilerplatePOC.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
