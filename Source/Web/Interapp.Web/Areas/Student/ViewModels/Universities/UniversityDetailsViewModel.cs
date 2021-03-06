﻿namespace Interapp.Web.Areas.Student.ViewModels.Universities
{
    using System.Collections.Generic;
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityDetailsViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? RequiredSAT { get; set; }

        public int? RequiredIBTToefl { get; set; }

        public int? RequiredPBTToefl { get; set; }

        public CambridgeResult? RequiredCambridgeScore { get; set; }

        public CambridgeLevel? RequiredCambridgeLevel { get; set; }

        public ICollection<DocumentViewModel> DocumentRequirements { get; set; }
    }
}