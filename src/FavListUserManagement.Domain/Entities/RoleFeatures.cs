using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class RoleFeatures
    {
        public Guid Id { get; set; }
        public Roles? Roles_Id { get; set; }
        public PortalFeature? PortalFeatures_Id { get; set; }
        public bool CanCreate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanView { get; set; }
        public Guid Create_by_id { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Last_update_date { get; set; }
        public Guid Update_by_id { get; set; }

    }
}
