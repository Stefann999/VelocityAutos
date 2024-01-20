using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityAutos.Common
{
    public static class EntityValidationConstants
    {
        public const int CarMakeMinLength = 2;
        public const int CarMakeMaxLength = 20;

        public const int CarModelMinLength = 2;
        public const int CarModelMaxLength = 30;

        public const int CarDescriptionMinLength = 10;
        public const int CarDescriptionMaxLength = 2000;

        public const int CarPriceMinValue = 0;
        public const int CarPriceMaxValue = 1_500_000;

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
    }
}
