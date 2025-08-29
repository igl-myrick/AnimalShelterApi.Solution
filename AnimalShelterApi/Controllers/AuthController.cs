using AnimalShelterApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AnimalShelterApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(Register registration)
    {
      ApplicationUser user = new ApplicationUser { UserName = registration.Username };
      IdentityResult result = await _userManager.CreateAsync(user, registration.Password);
      if (result.Succeeded)
      {
        return NoContent();
      }
      else
      {
        return BadRequest();
      }
    }
  }
}