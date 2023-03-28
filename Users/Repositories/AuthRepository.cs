using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Products.DataAccess;
using Products.Models;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Users.DataAccess.Interfaces;

namespace Users.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly EcommerceContext _ecommerceContext;


        private readonly IConfiguration _configuration;

        public AuthRepository(EcommerceContext ecommerceContext, IConfiguration configuration)
        {
            _ecommerceContext = ecommerceContext;
            _configuration = configuration;
        }

        public string generateToken(Tuser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim("UserName", user.UserName.ToString()),
                new Claim("UserEmail", user.UserEmail.ToString()),
                new Claim("UserRole", user.UserRole.ToString()),
                new Claim("UserPassword", user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            };

            var tokens = new JwtSecurityToken(_configuration["jwt:Issuer"],
                _configuration["jwt:Audience"],
                tokenClaims,
                expires: DateTime.Now.AddMinutes(24000),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokens);

        }

        public UserDTO LoginUser(UserDTO user)
        {
            try
            {
                if (user != null)
                {
                    var userExist = _ecommerceContext.Tusers.Where(u => u.UserEmail == user.UserEmail && u.UserPassword == user.UserPassword).FirstOrDefault();

                    if (userExist != null)
                    {
                        user.Message = "Login Successful!";
                        user.Token = generateToken(userExist);
                        user.UserRole = userExist.UserRole;
                        user.UserId = userExist.UserId;
                        user.UserName = userExist.UserName;
                        user.UserEmail = userExist.UserEmail;
                        user.CartId = userExist.CartId;

                        return user;
                    }
                    else
                    {
                        throw new Exception("User doesn't exist");
                    }
                }
                else
                {
                    throw new Exception("Please enter user details!");
                }
            }
            catch (Exception loginException)
            {
                throw new Exception(loginException.Message);
            }
        }

        public async Task<UserDTO> RegisterUser(Tuser user)
        {
            try
            {
                var cart = new Tcart()
                {
                    Discount = 0,
                    TotalCost = 0,
                };

                await _ecommerceContext.Tcarts.AddAsync(cart);
                await _ecommerceContext?.SaveChangesAsync();

                var newCart = _ecommerceContext.Tcarts.OrderByDescending(a => a.CartId).First();

                user.CartId = newCart.CartId;
                _ecommerceContext?.Tusers.AddAsync(user);
                await _ecommerceContext?.SaveChangesAsync();

                var newUser = new UserDTO()
                {
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    UserPassword = user.UserPassword,
                    UserRole = user.UserRole,
                    Message = "Login Successful!",
                    Token = generateToken(user),
                    CartId = newCart.CartId,
                };

                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
