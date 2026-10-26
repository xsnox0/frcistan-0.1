using System.ComponentModel.DataAnnotations;

namespace Frcistan
{
    public class Kullanici
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string KullaniciAdi { get; set; }

        [Required, MaxLength(64)]
        public string Sifre { get; set; }

        // Admin veya Personel
        [Required, MaxLength(20)]
        public string Rol { get; set; }
    }
}
