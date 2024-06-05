using ASP.NET_API.Model;

namespace ASP.NET_API.Services
{
    public class LoaiRepositoryInMemory : ILoaiRepository
    {
        static List<Loai> loais = new List<Loai>()
        {
            new Loai{MaLoai =1, TenLoai ="Laptop"},
            new Loai{MaLoai =2, TenLoai ="TiVi"},
            new Loai{MaLoai =3, TenLoai ="TuLanh"},
            new Loai{MaLoai =3, TenLoai ="Quat"},
        };
        public Loai Add(Loai loai)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Loai> GetAll()
        {
            throw new NotImplementedException();
        }

        public Loai GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Loai loai)
        {
            throw new NotImplementedException();
        }
    }
}
