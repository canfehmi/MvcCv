using System.ComponentModel.DataAnnotations;

namespace MvcCv.DAL.Entities
{
    public class Hobby
    {
        [Key]
        public int ID { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
    }
}
