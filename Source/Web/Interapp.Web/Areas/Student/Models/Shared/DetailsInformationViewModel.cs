﻿namespace Interapp.Web.Areas.Student.Models.Shared
{
    using Services.Common;
    using StudentInfoViewModels;
    using UniversityViewModels;

    public class DetailsInformationViewModel
    {
        public UniversityDetailsViewModel University { get; set; }

        public StudentInfoApplicationViewModel Student { get; set; }

        public ApplicationEligibility Eligibility { get; set; }
    }
}