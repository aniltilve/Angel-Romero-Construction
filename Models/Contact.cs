using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace ARC.Models
{
    public class Contact
    {
        [Key]
        public int contactID { get; set; }
        [DisplayName("Name:")]
        [Required(ErrorMessage = "Please enter your name.")]
        public string name { get; set; }
       // [Required(ErrorMessage = "Please enter your email address")]
        [DisplayName("Phone:")]
        [Required(ErrorMessage = "Please enter your phone number.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string phone { get; set; }
        [DisplayName("Email:")]
       // [RegularExpression(@"^ ([\w\.\-] +)@([\w\-] +)(([\.\w\-] +))((\.(\w){2, 3})+)$", ErrorMessage = "Entered email format is not valid.")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter a comment.")]
        [DisplayName("Comment:")]
        public string comment { get; set; }
        public DateTime creationDate { get; set; }
        public bool emailSentFlag { get; set; }
    }
}