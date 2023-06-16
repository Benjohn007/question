using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.Entities
{
    public class Sponsor : BaseEntity
    {
        public string? Name { get; set; }
        public string? Logo_S3_Url { get; set; }
        public string? Ads_S3_Url { get;set; }
    }
}
