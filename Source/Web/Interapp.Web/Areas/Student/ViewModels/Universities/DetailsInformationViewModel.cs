namespace Interapp.Web.Areas.Student.ViewModels.Universities
{
    using Services.Common;

    public class DetailsInformationViewModel
    {
        public UniversityDetailsViewModel University { get; set; }

        public StudentInfoApplicationViewModel Student { get; set; }

        public ApplicationEligibility Eligibility { get; set; }
    }
}