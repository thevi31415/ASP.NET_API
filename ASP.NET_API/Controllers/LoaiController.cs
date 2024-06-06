using ASP.NET_API.Data;
using ASP.NET_API.Migrations;
using ASP.NET_API.Model;
using ASP.NET_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly ILoaiRepository _loaiRepository   ;
        public LoaiController(ILoaiRepository loaiRepository) {
        
            _loaiRepository = loaiRepository; 
        
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_loaiRepository.GetAll());
            }
            catch
            {
                return BadRequest();
            }

        
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _loaiRepository.GetById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                   return NotFound();
                }
    
            }
            catch
            {
                return BadRequest();
            }


        }
        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, Loai loai)
        {
            if (id != loai.MaLoai)
            {
                return NotFound();
            }
            try
            {
                _loaiRepository.Update(loai);
                return Ok(loai);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
         
            try
            {
                _loaiRepository.Delete(id);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(Loai loai)
        {
            Console.WriteLine("Ten: " + loai.TenLoai);

            try
            {

                return Ok(_loaiRepository.Add(loai));

            }
            catch
            {
                return BadRequest();
            }

        }
  

    }
}
