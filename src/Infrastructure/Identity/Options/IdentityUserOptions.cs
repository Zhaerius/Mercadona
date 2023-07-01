using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Options
{
    public class IdentityUserOptions
    {
        public required string UserName { get; init; }
        public required string Password { get; init; }
        public required IEnumerable<string> Roles { get; init; }
    }
}
