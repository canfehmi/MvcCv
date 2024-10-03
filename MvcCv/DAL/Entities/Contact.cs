using System.ComponentModel.DataAnnotations;

namespace MvcCv.DAL.Entities
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
