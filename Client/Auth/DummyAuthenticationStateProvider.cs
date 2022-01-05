using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Datacar.Client.Auth
{
    public class DummyAuthenticationStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymous = new ClaimsIdentity(new List<Claim>() {
            new Claim("key2","Value1"),
            new Claim(ClaimTypes.Name,"Alexandre"),
            new Claim(ClaimTypes.Role,"Admin")
            });

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));

        }
    }
}
