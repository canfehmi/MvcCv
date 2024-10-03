using System.ComponentModel.DataAnnotations;

namespace MvcCv.DAL.Entities
{
    public class Sertificate
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]

        public string Date { get; set; }

    }
}
