namespace VelocityAutos.Common
{
    public static class EntityValidationConstants
    {

        public static class Car
        {
            public const int CarMakeMinLength = 2;
            public const int CarMakeMaxLength = 20;

            public const int CarModelMinLength = 2;
            public const int CarModelMaxLength = 30;

            public const int CarDescriptionMinLength = 10;
            public const int CarDescriptionMaxLength = 2000;

            public const string CarPriceMinValue = "0";
            public const string CarPriceMaxValue = "1500000";

            public const int CarMonthMinValue = 1;
            public const int CarMonthMaxValue = 12;

            public const int CarYearMinValue = 1900;
            public const int CarYearMaxValue = 2024;

            public const int CarHorsePowerMinValue = 0;
            public const int CarHorsePowerMaxValue = 2_000;

            public const int CarMileageMinValue = 0;
            public const int CarMileageMaxValue = 1_000_000;

            public const int CarFuelConsumptionMinValue = 0;
            public const int CarFuelConsumptionMaxValue = 100;

            public const int CarLocationCityMinLength = 3;
            public const int CarLocationCityMaxLength = 40;

            public const int CarLocationCountryMinLength = 3;
            public const int CarLocationCountryMaxLength = 30;

            public const int TransmissionTypeMinLength = 3;
            public const int TransmissionTypeMaxLength = 30;
        }

        public static class Category
        {
            public const int CategoryNameMinLength = 3;
            public const int CategoryNameMaxLength = 30;
        }

        public static class Post
        {
            public const int SellerFirstNameMinLength = 2;
            public const int SellerFirstNameMaxLength = 20;

            public const int SellerLastNameMinLength = 2;
            public const int SellerLastNameMaxLength = 20;

            public const int SellerPhoneNumberMinLength = 6;
            public const int SellerPhoneNumberMaxLength = 20;

            public const string SellerEmailAddressRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        }

        public static class User
        {
            public const int UserFirstNameMinLength = 3;
            public const int UserFirstNameMaxLength = 20;

            public const int UserLastNameMinLength = 3;
            public const int UserLastNameMaxLength = 20;

            public const int UserPasswordMinLength = 6;
            public const int UserPasswordMaxLength = 100;

            public const int UserPhoneNumberMinLength = 6;
            public const int UserPhoneNumberMaxLength = 20;
        }
    }
}
