﻿namespace Interapp.Web.Areas.Student.Models.DocumentViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;
    using UniversityViewModels;

    public class DocumentViewModel : IMapFrom<Document>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.DocumentNameMinLength)]
        [MaxLength(ModelConstants.DocumentNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        public UniversityViewModel University { get; set; }
    }
}