using BlogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogService.Repository
{
    public interface ITokenRepository
    {
       Task<UserInfo> GetUser(string email, string password);
    }
}
