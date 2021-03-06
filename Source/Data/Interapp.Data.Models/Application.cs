﻿namespace Interapp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Application : BaseModel
    {
        [Key]
        public int Id { get; set; }

        public bool IsReviewed { get; set; }

        public bool IsAnswered { get; set; }

        [Required]
        public int UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public virtual University University { get; set; }

        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual StudentInfo Student { get; set; }

        [Required]
        public int MajorId { get; set; }

        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }

        public int? ResponseId { get; set; }

        [ForeignKey("ResponseId")]
        public virtual Response Response { get; set; }
    }
}
