using System.ComponentModel.DataAnnotations;

namespace MvcCv.DAL.Entities
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız!")]
        public string SocialMediaName { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız!")]
        public string SocialMediaUrl { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}
