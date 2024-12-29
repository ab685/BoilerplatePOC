using System.Collections.Generic;
using BoilerplatePOC.Roles.Dto;

namespace BoilerplatePOC.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}