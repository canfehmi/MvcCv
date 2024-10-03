using System.ComponentModel.DataAnnotations;

namespace MvcCv.DAL.Entities
{
    public class Education
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Subdescription1 { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Subdescription2 { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string GNO { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Date { get; set; }
    }
}
