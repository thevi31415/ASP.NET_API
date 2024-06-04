using ASP.NET_API.Data;
using ASP.NET_API.Migrations;
using ASP.NET_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDBContext _db;
        public LoaiController(MyDBContext db)
        {
            _db = db;
        }


        [HttpPost]
        public IActionResult CreateNew(Loai loai)
        {
            Console.WriteLine("Ten: " + loai.TenLoai);

            try { 


                var loaifinal = new Loai
                {
                 
                    TenLoai = loai.TenLoai
            };
                _db.Add(loaifinal);
                _db.SaveChanges();
                return Ok(loaifinal);

            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet]
        public IActionResult GetAll()
        {
           var dsLoai = _db.loais.ToList();

            return Ok(dsLoai);
        }


        [HttpGet("{id}")]
        public IActionResult GetMyId(int id)
        {
            var Loai = _db.loais.SingleOrDefault(lo =>lo.MaLoai ==id) ;
            if (Loai != null)
            {
                return Ok(Loai);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, Loai loai)
        {
            var Loai = _db.loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (Loai != null)
            {
                Loai.TenLoai = loai.TenLoai;
                _db.SaveChanges();
                return Ok(Loai);

            }
            else
            {
                return NotFound();
            }
        }
    }
}
