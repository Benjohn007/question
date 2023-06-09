using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class RoleFeature: BaseEntity
    {
        //public UserRole? Roles_Id { get; set; }
        public PortalFeature? PortalFeatures_Id { get; set; }
        public bool CanCreate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanView { get; set; }

    }
}
