using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementWebAPI.DTO;
using ProductManagementWebAPI.Models;
using Repository.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ProductManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly ILoginOperation login;
        public LoginController(ILoginOperation log)
        {
            login = log;
        }

        [HttpGet("Token")]
        public  IActionResult GetToken([FromBody]User user)
        {
           var data =  login.GenerateToken(user);
            return Ok(data);
        }

        [HttpGet("ValidateToken")]
        public IActionResult GetValidate(string token)
        {
            var data = login.ValidationToken(token);

            return Ok(data);
        }

        [HttpGet("UserId/{username}")]
        public async Task<IActionResult> GetIdByUsername([FromRoute]string username)
        {
           var data = await login.GetIdByUsername(username);

            return Ok(data);
        }

        [HttpGet("Credential")]
        public async Task<IActionResult> GetCredentials([FromBody]LoginDto user)
        {
            var data = await login.LoginEntAsync(user);
            if (data != null)
                return Ok(data);
            else return NotFound();
        }
    }
}
