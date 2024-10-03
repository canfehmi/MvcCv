using System.ComponentModel.DataAnnotations;

namespace MvcCv.DAL.Entities
{
    public class About
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
