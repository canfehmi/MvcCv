using System.ComponentModel.DataAnnotations;

namespace MvcCv.DAL.Entities
{
    public class Experience
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız!")]

        public string Subdescription { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız!")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız!")]

        public string Date { get; set; }


    }
}
