using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.DTO
{
    public class SponsorDto
    {
        public string? Name { get; set; }
        public string? Logo_S3_Url { get; set; }
        public string? Ads_S3_Url { get; set; }
    }
}
