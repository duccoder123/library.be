using library.be.Data;
using library.be.Domain;
using library.be.Models;
using library.be.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace library.be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ApiResponse _response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private string _secretKey;
        public AuthenticationController(
            ApplicationDbContext context,
            IConfiguration config,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager
            )
        {
            _context = context;
            _secretKey = config.GetValue<string>("ApiSettings:SecretKey");
            _response = new ApiResponse();
            _userManager = userManager;
            _roleManager = roleManager; 
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            ApplicationUser userFrDb = _context.applicationUsers.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(userFrDb, model.Password);
            if (!isValid)
            {
                _response.Result = new LoginReponseDto();
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or Password in incorrect");
                return BadRequest(_response);
            }
            // generate JWT Token
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.UTF8.GetBytes(_secretKey);

    }
}
