using System.Collections.Generic;
using BoilerplatePOC.Roles.Dto;

namespace BoilerplatePOC.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
