using ASP.NET_API.Data;
using ASP.NET_API.Model;

namespace ASP.NET_API.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDBContext _db;
        public LoaiRepository(MyDBContext db) {
            _db = db;
        }
        public Loai Add(Loai loai)
        {
            var _loai = new Loai
            {
                TenLoai = loai.TenLoai
            };
           _db.Add(_loai);
           _db.SaveChanges();
            return new Loai
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai
            };

        }

        public void Delete(int id)
        {
            var loai = _db.loais.SingleOrDefault(x => x.MaLoai == id);
            if(loai != null)
            {
                _db.loais.Remove(loai);
                _db.SaveChanges();
            }
        }

        public List<Loai> GetAll()
        {
            var loais = _db.loais.ToList();
            return loais;   
        }

        public Loai GetById(int id)
        {
            var loai = _db.loais.SingleOrDefault(x => x.MaLoai == id);
            return loai;
        
        }

        public void Update(Loai loai)
        {
            var _loai = _db.loais.SingleOrDefault(x => x.MaLoai == loai.MaLoai);
            _loai.TenLoai = loai.TenLoai;
            _db.SaveChanges();



          
        }
    }
}
