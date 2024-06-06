using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_API.Model
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string HoTen { get; set; }   
        public string Email { get; set; }

      
       
    }
}
