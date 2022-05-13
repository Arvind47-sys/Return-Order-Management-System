using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<int> GetUserId(string username);
        Task<bool> UserExists(string userName);
        Task AddNewUser(AppUser user);
        Task<AppUser> GetUser(string username);
    }
}
