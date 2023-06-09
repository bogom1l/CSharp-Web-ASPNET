﻿using System.Net.NetworkInformation;

namespace Library.GlobalConstants
{
    public static class GlobalConstants
    {
        public static class BookConstants
        {
            public const int BookTitleMaxLength = 50;
            public const int BookTitleMinLength = 10;

            public const int BookAuthorMaxLength = 50;
            public const int BookAuthorMinLength = 5;

            public const int BookDescriptionMaxLength = 5000;
            public const int BookDescriptionMinLength = 5;

            public const double BookRatingMaxValue = 10.00;
            public const double BookRatingMinValue = 0.00;
        }

        public static class CategoryConstants
        {
            public const int CategoryNameMaxLength = 50;
            public const int CategoryNameMinLength = 5;
        }

    }
}
