using ASP.NET_API.Model;

namespace ASP.NET_API.Services
{
    public interface IUserRepository
    {
        NguoiDung Validate(LoginModel model);
    }
}
