using System.ComponentModel.DataAnnotations;

namespace MvcCv.DAL.Entities
{
    public class Skill
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız!")]
        public string SkillName { get; set; }
        [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız!")]

        public byte Progress { get; set; }
    }
}
