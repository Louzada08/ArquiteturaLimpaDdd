﻿//using ArqLimpaDDD.Application.Services.Token;
//using ArqLimpaDDD.Domain.Configuration;
//using ArqLimpaDDD.Domain.Interfaces.Repositories;
//using ArqLimpaDDD.Domain.ValueObjects;

//namespace ArqLimpaDDD.Application.Services.Login
//{
//    public class LoginServiceImplementation : ILoginService
//    {
//        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
//        private TokenConfiguration _configuration;

//        private IUserRepository _repository;
//        private readonly ITokenService _tokenService;

//        public LoginServiceImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
//        {
//            _configuration = configuration;
//            _repository = repository;
//            _tokenService = tokenService;
//        }

//        //public TokenVO ValidateCredentials(UserVO userCredentials)
//        //{
//        //    var user = _repository.ValidateCredentials(userCredentials);
//        //    if (user == null) return null;

//        //   // var accessToken = _tokenService.GenerateAccessToken(user);
//        //    var refreshToken = _tokenService.GenerateRefreshToken();

//        //    user.RefreshToken = refreshToken;
//        //    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

//        //   // _repository.RefreshUserInfo(user);

//        //    DateTime createDate = DateTime.Now;
//        //    DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);


//        //    return new TokenVO(
//        //        true,
//        //        createDate.ToString(DATE_FORMAT),
//        //        expirationDate.ToString(DATE_FORMAT),
//        //        accessToken,
//        //        refreshToken
//        //    );
//        //}

//        //public TokenVO ValidateCredentials(TokenVO token)
//        //{
//        //    var accessToken = token.AccessToken;
//        //    var refreshToken = token.RefreshToken;

//        //    var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

//        //    var username = principal.Identity.Name;

//        //    var user = _repository.ValidateCredentials(username);

//        //    if (user == null ||
//        //        user.RefreshToken != refreshToken ||
//        //        user.RefreshTokenExpiryTime <= DateTime.Now) return null;

//        //    accessToken = _tokenService.GenerateAccessToken(principal.Claims);
//        //    refreshToken = _tokenService.GenerateRefreshToken();

//        //    user.RefreshToken = refreshToken;

//        //    _repository.RefreshUserInfo(user);

//        //    DateTime createDate = DateTime.Now;
//        //    DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

//        //    return new TokenVO(
//        //        true,
//        //        createDate.ToString(DATE_FORMAT),
//        //        expirationDate.ToString(DATE_FORMAT),
//        //        accessToken,
//        //        refreshToken
//        //        );
//        //}

//        //public bool RevokeToken(string userName)
//        //{
//        //    return _repository.RevokeToken(userName);
//        //}
//    }
//}
