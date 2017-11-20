using System.ComponentModel.DataAnnotations;

namespace ARC.Models
{
    public class ImageType
    {
        [Key]
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }
}