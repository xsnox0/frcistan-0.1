using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frcistan
{
    public class Urun
    {
        public int Id { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }

        [Required, MaxLength(50)]
        public string Marka { get; set; }

        [Required, MaxLength(100)]
        public string UrunAdi { get; set; }

        public int Adet { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Fiyat { get; set; }
    }
}
