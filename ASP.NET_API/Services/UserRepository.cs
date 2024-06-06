using ASP.NET_API.Data;
using ASP.NET_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_API.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDBContext _db;
        public UserRepository(MyDBContext db)
        {
            _db = db;
        }
        NguoiDung IUserRepository.Validate(LoginModel model)
        {
            var user = _db.nguoiDungs.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);

            return user;
        }

        
    }
}
