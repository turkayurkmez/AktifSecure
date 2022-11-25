using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace BasicAuthOnAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOption>
    {

        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOption> options,
                                          ILoggerFactory loggerFactory,
                                          UrlEncoder urlEncoder,
                                          ISystemClock systemClock
                                          ) :
                                         base(options, loggerFactory, urlEncoder, systemClock)
        {

        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //1. gelen request'de Authorization değeri var mı?
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //2. Bu Authorization değeri standart format mı?
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //3. headerValue değeri; Basic mi?
            if (!headerValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }
            /*
             *    'turkay:123';
             */

            byte[] incomingCredential = Convert.FromBase64String(headerValue.Parameter);
            string userCredential = Encoding.UTF8.GetString(incomingCredential);
            string username = userCredential.Split(':')[0];
            string password = userCredential.Split(':')[1];

            if (username != "turkay" && password != "123")
            {
                return Task.FromResult(AuthenticateResult.Fail("Hatalı giriş"));
            }

            Claim[] claims = new Claim[] { new Claim(ClaimTypes.Name, username) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            AuthenticationTicket ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));

        }
    }
}
