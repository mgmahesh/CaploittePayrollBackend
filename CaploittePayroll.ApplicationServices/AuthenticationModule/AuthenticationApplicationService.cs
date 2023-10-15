using CaploittePayroll.BusinessObjects.AuthenticationModule;
using CaploittePayroll.BusinessObjects.Common;
using CaploittePayroll.DAL;
using CaploittePayroll.DAL.AuthenticationModule;
using CaploittePayroll.DAL.Interface.AuthenticationModule;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CaploittePayroll.ApplicationServices.AuthenticationModule
{
    public class AuthenticationApplicationService
    {
        IDataService dataService;
        public AuthenticationResponse Authenticate(AccessTokenRequest user)
        {
            AuthenticationResponse authenticationResponse = null;

            try
            {
                dataService = DataServiceBuilder.CreateDataService();
                IAuthenticationDataService ads = new AuthenticateDataServices(dataService);
                var loggedUser = ads.UserLogin(user);
                if (loggedUser.UserName == null) return null;

                var jwtToken = generateJwtToken(loggedUser);

                authenticationResponse = new AuthenticationResponse(loggedUser.RoleName, user.Username, jwtToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return authenticationResponse;
        }
        private string generateJwtToken(LoggedUser user)
        {
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "caploitte",
                audience: "caploitte-audience",
                claims: new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim("Role",user.RoleName),
                    new Claim(ClaimTypes.Role, user.RoleName) 
                },
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(
                    key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Secret)),
                    algorithm: SecurityAlgorithms.HmacSha256
                )
            );

            return (new JwtSecurityTokenHandler()).WriteToken(token);
        }


    }
}
