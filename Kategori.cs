using System.ComponentModel.DataAnnotations;

namespace Frcistan
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Ad { get; set; }
    }
}
