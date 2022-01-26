using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Datacar.Shared.DTOs
{
    public class UserClaims
    {
        public string UserId { get; set; }
        public string ClaimValue { get; set; }
    }
}
