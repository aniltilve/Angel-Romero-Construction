using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARC.Models
{
    public class Review
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Title:")]
        [Required(ErrorMessage = "Please enter a title.")]
        public string title { get; set; }
        [DisplayName("Name:")]
        [Required(ErrorMessage = "Please enter your name.")]
        public string name { get; set; }
        [DisplayName("Rating:")]
        [RegularExpression("[1-5]{1}", ErrorMessage = "Please enter a value from 1 to 5.")]
        public int rating { get; set; }
        [DisplayName("Comment:")]
        [Required(ErrorMessage = "Please enter a comment.")]
        public string comment { get; set; }

        public DateTime creationDate { get; set; }
        [NotMapped]
        public IList<Review> reviews { get; set; }

    }
}