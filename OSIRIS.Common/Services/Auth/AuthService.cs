using Microsoft.IdentityModel.Tokens;
using OSIRIS.Common.Exceptions;
using OSIRIS.Common.Helpers;
using OSIRIS.Common.Responses;
using OSIRIS.Database;
using OSIRIS.Database.Domain;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OSIRIS.Common.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AuthSettings _appSettings;
        private readonly OSIRISDbContext _db;
        
        public AuthService(AuthSettings appSettings, OSIRISDbContext db)
        {
            _appSettings = appSettings;
            _db = db;
        }

        /// <summary>
        /// Log the user in
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            var user = _db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (user==null)
            {
                throw new NotFoundException(nameof(email));
            }

            var verifyPass = PasswordGenerator.Validate(password, user.Password);

            if (!verifyPass)
            {
                throw new CustomException("Invalid credentials entered.");
            }
            var token = GenerateUserToken(email, user.Id);

            return await Task.FromResult(token);
        }

        /// <summary>
        /// Refresh user token.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {

            CheckAppUser(email);
            var hashedPass = PasswordGenerator.GenerateHashedPassword(password);
            _db.Users.Add(new AppUser { Email=email, Password= hashedPass });
           var id = await _db.SaveChangesAsync();
            ///
            var token = GenerateUserToken(email, id);

            return await Task.FromResult(token);

        }

        private AppUser CheckAppUser(string email)
        {
            var check = _db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            ///Register
            if (check != null)
            {
                throw new UserExistException(nameof(email));
            }
            return check;
        }

        private AuthenticationResult GenerateUserToken(string email, int userId=0)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult {
                Success=true,
                Token= tokenHandler.WriteToken(token),
            };
        }
    }
}
