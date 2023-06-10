using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.Utilities
{
    public class RefreshToken
    {
        public string Refreshtoken { get; set; } = string.Empty;
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
