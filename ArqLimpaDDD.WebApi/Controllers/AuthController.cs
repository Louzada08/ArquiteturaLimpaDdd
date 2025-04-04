using ArqLimpaDDD.Application.Commands.Users.Requests;
using ArqLimpaDDD.Application.Interfaces.Users;
using ArqLimpaDDD.Application.Services.Token;
using ArqLimpaDDD.Domain.Dtos;
using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Validation;
using ArqLimpaDDD.Domain.ValueObjects;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArqLimpaDDD.WebApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IMapper mapper, IMediator mediator, ITokenService tokenService,
                 IUserService userService, IConfiguration configuration) : base(mapper, mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userService = userService;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        /// <summary>
        /// Gera um novo token para o usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Signin")]
        public async Task<IActionResult> Signin([FromBody] UserLoginDTO userLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                if (userLogin == null) return BadRequest("Usuario invalido!");

                var user = await _userService.ValidationUser(userLogin);
                
                var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

                //if(result.Succeeded)
                //{
                //    return CustomResponse(await GerarJwt(userLogin.Email));
                //}

                if (user == null)
                {
                    var bag = new ValidationResultBag();
                    bag.Errors.Add(new FluentValidation.Results.ValidationFailure("error", "Usuario ou Senha, invalido"));
                    return CustomResponse(bag);
                }

                var users = await _userManager.FindByEmailAsync(userLogin.Email);
                var claims = await _userManager.GetClaimsAsync(users);

                var tokenVO = _tokenService.GenerateAccessToken(userLogin.Email, user.UserRole, claims);
                return CustomResponse(tokenVO);
            }
            catch (Exception ex)
            {
                var bag = new ValidationResultBag();
                bag.Errors.Add(new FluentValidation.Results.ValidationFailure("error", ex.Message));
                return CustomResponse(bag);
            }
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest command)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = command.Email,
                Email = command.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, command.Password);


            try
            {
                if (command is null) return CustomResponse(new { Status = StatusCodes.Status400BadRequest, Error = "Token Vazio!!!" });

               // var response = await _mediator.Send(command);

                var tokenVM = CustomResponse(await GerarJwt(command.Email));

               // var tokenVM = _tokenService.GenerateAccessToken(command.Email, command.UserRole);

                return CustomResponse(tokenVM);
            }
            catch (Exception ex)
            {
                var bag = new ValidationResultBag();
                bag.Errors.Add(new FluentValidation.Results.ValidationFailure("error", ex.Message));
                return CustomResponse(bag);
            }
        }


        /// <summary>
        /// Refresh token
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo is null) return BadRequest("Solicitação de cliente inválida");
            //var token = _loginService.ValidateCredentials(tokenVo);
           // if (token == null) return BadRequest("Solicitação de cliente inválida");
            return Ok();
        }

        /// <summary>
        /// Cancela o token do usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
           // var result = _loginService.RevokeToken(username);

           // if (!result) return BadRequest("Solicitação de cliente inválida");
            return NoContent();
        }

        private async Task<UsuarioRespostaLogin> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
           
            claims.Append(new Claim(ClaimTypes.Name, user.Email));


            var Claims = new Dictionary<string, object>();

            //var identityClaims = await ObterClaimsUsuario(claims, user);
            var encodedToken = CodificarToken(claims);

            return ObterRespostaToken(encodedToken, user, claims);
        }

        private async Task<IEnumerable<Claim>> ObterClaimsUsuario(IEnumerable<Claim> claims, IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            //claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            //claims.Add(ClaimTypes.Name, user.Email);
            //claims.Add(ClaimTypes.Role, UserRolesEnum.Administrator.ToString());

            foreach (var userRole in userRoles)
            {
                claims.Append(new Claim(ClaimTypes.Role, userRole));
            }

            // var identityClaims = new ClaimsIdentity();
            //  identityClaims.AddClaims(claims);

            return claims;
        }

        private string CodificarToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["TokenConfigurations:Secret"] ?? string.Empty));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

            var issuer = _configuration["TokenConfigurations:Issuer"];
            var audience = _configuration["TokenConfigurations:Audience"];
            var expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["TokenConfigurations:Minutes"] ?? "2"));

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = secretKey;
            //var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            //{
            //    Issuer = issuer,
            //    Audience = audience,
            //    // Subject = identityClaims,
                
            //    Claims = claims,
            //    Expires = expires,
            //    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            //});

            return tokenHandler.WriteToken(token);
        }

        private static long ToUnixEpochDate(DateTime date)
    => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private UsuarioRespostaLogin ObterRespostaToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
        {
            var expires = TimeSpan.FromHours(int.Parse(_configuration["TokenConfigurations:Minutes"] ?? "2")).TotalSeconds;

            return new UsuarioRespostaLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = expires,
                UsuarioToken = new UsuarioToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UsuarioClaim { Type = c.Type, Value = c.Value })
                }
            };
        }

    }
}
