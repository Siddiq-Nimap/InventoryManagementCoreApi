using ProductManagementWebAPI.DTO;
using ProductManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface ILoginOperation 
    {
        string GenerateToken(User user);

        ClaimsPrincipal ValidationToken(string token);

       Task<int> GetIdByUsername(string username);

        Task<User> LoginEntAsync(LoginDto user);

        


    }
}
