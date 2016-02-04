﻿namespace Interapp.Common.Constants
{
    public class ModelConstants
    {
        public const int CountryNameMinLength = 2;
        public const int CountryNameMaxLenght = 30;

        public const int UniversityNameMinLength = 5;
        public const int UniversityNameMaxLength = 80;
        public const int UniversityTuitionFeeMin = 0;
        public const int UniversityTuitionFeeMax = 100000;

        public const int MajorNameMinLength = 10;
        public const int MajorNameMaxLength = 80;

        public const int EssayTitleMinLength = 2;
        public const int EssayTitleMaxLength = 80;
        public const int EssayContentMinLength = 1800;
        public const int EssayContentMaxLength = 3600;

        public const int DocumentNameMinLength = 2;
        public const int DocumentNameMaxLength = 40;

        public const int ScoreSatMin = 200;
        public const int ScoreSatMax = 800;
        public const int ScoreToeflMin = 0;
        public const int ScoreToeflMax = 677;
        public const string ScoreCambridgeResultRegex = "^[ABC]{1}$";
    }
}
