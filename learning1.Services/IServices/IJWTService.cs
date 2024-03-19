using learning1.DBEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning1.Services.IServices
{
    public interface IJWTService
    {
        string GenerateJWTToken(UserInfoViewModel model);
        public bool ValidateToken(string token, out JwtSecurityToken jwtSecurityToken);
    }
}
