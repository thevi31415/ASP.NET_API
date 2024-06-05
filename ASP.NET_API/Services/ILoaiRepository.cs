using ASP.NET_API.Model;

namespace ASP.NET_API.Services
{
    public interface ILoaiRepository
    {
        List<Loai> GetAll();
        Loai GetById(int id);
        Loai Add(Loai loai);
        void Update(Loai loai); 
        void Delete(int id);
    }
}
