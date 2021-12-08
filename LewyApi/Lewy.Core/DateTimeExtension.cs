using System;

namespace Lewy.Core
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime Dob)
        {
            var today = DateTime.Today;
            var age = today.Year - Dob.Year;

            if (Dob.Date > today.AddYears(-age)) age--;

            return age;
        }
        
    }
}
