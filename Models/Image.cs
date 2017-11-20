using System.ComponentModel.DataAnnotations;

namespace ARC.Models
{
    public class ARCImage
    {
        [Key]
        public int id { get; set; }
        public int typeID { get; set; }
        public byte[] image { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public int sort_order { get; set; }
    }
}