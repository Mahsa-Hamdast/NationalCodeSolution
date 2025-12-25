using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCode.Application.Services
{
    public static class NationalCodeValidator
    {

        public static bool IsValid(string nationalCode)
        {
            if (string.IsNullOrEmpty(nationalCode))
            {
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(nationalCode, @"^\d{10}$"))
            {
                return false;
            }
            var invalidCodes = new[]
             {
            "0000000000", "1111111111", "2222222222",
            "3333333333", "4444444444", "5555555555",
            "6666666666", "7777777777", "8888888888", "9999999999"
             };

            if (invalidCodes.Contains(nationalCode))
            {
                return false;
            }
            if (nationalCode.Length != 10)
            {
                return false;
            }
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += (nationalCode[i] - '0') * (10 - i);
            }
            int remainder = sum % 11;
            int controlDigit = nationalCode[9] - '0';


            return remainder < 2
                  ? controlDigit == remainder
                  : controlDigit == (11 - remainder);
        }
    }
}
