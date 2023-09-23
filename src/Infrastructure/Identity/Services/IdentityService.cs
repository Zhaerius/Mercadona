using Application.Core.Abstractions;
using Application.Core.Common.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> SignInAsync(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
            return result.Succeeded;
        }

        public async Task<IList<string>> GetRolesByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName) 
                ?? throw new NotFoundException();

            return await _userManager.GetRolesAsync(user);
        }
    }
}
