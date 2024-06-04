using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_API.Model
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai {  get; set; }
        public string TenLoai { get; set; }

    }
}
