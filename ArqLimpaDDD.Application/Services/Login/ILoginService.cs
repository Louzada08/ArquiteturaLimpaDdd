using ArqLimpaDDD.Domain.ValueObjects;

namespace ArqLimpaDDD.Application.Services.Login
{
    public interface ILoginService
    {
        TokenVO ValidateCredentials(UserVO user);
        //TokenVO ValidateCredentials(TokenVO token);
        //bool RevokeToken(string userName);
    }
}
