using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArqLimpaDDD.InterfaceAdapter.ViewModels;
using ArqLimpaDDD.Application.Commands.Users.Requests;
using ArqLimpaDDD.Application.Interfaces.Users;
using ArqLimpaDDD.Application.Services.Token;
using ArqLimpaDDD.Domain.Validation;
using ArqLimpaDDD.Domain.ValueObjects;

namespace ArqLimpaDDD.WebApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AuthController : MainController
    {
        private readonly TokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(IMapper mapper, IMediator mediator, TokenService tokenService,
                 IUserService userService) : base(mapper, mediator)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Gera um novo token para o usuário
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> Signin([FromBody] CreateUserRequest command)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                if (command is null) return CustomResponse(new { Status = StatusCodes.Status400BadRequest, Error = "Token Vazio!!!" });

                var response = await _mediator.Send(command);

                var tokenVM = _mapper.Map<TokenViewModel>(response);

                return CustomResponse(tokenVM);
            }
            catch (Exception ex)
            {
                var bag = new ValidationResultBag();
                bag.Errors.Add(new ValidationFailure("error", ex.Message));
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
    }
}
