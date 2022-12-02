using System.ComponentModel.DataAnnotations;

namespace RumahSakitAPI.Models
{
    public class Pasien
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama harus diisi")]
        public string? Nama { get; set; }

        [Required (ErrorMessage = "Alamat harus diisi")]
        public string? Alamat { get; set; }

        [Required(ErrorMessage = "Tanggal Harus diisi")]
        [DataType(DataType.Date)]

        [Display(Name = "Tanggal Lahir")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? TanggalLahir { get; set; }

        public string? NomorHP { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
