using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Abstractions
{
    public interface IIdentityService
    {
        Task<bool> SignInAsync(string userName, string password);

        Task<IList<string>> GetRolesByUserNameAsync(string userName);
    }
}
