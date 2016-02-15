namespace Interapp.Web.Areas.Student.Models.UniversitiesViewModels
{
    using Services.Common;

    public class DetailsInformationViewModel
    {
        public UniversityDetailsViewModel University { get; set; }

        public StudentInfoApplicationViewModel Student { get; set; }

        public ApplicationEligibility Eligibility { get; set; }
    }
}