using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Abstractions
{
    public interface IJwtService
    {
        public string GenerateJwtToken(string userName, IList<string> role);
    }
}
