﻿namespace Interapp.Web.Areas.Director.ViewModels.Universities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;

    public class UniversityCreateViewModel
    {
        [Required]
        [Display(Name = "University name")]
        [MinLength(ModelConstants.UniversityNameMinLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(ModelConstants.UniversityNameMaxLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [RegularExpression(ModelConstants.UniversityNameRegex, ErrorMessage = "University name may contain only Letters, Dashes, Brackets, Comma, Apostrophe, Whitespaces and &.")]
        public string Name { get; set; }

        [Display(Name = "Tuition fee")]
        [Required]
        [Range(ModelConstants.UniversityTuitionFeeMin, ModelConstants.UniversityTuitionFeeMax, ErrorMessage = "{0} must be between {1:C} and {2:C}")]
        public int TuitionFee { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}